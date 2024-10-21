import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EventCreateRequest } from 'src/app/models/request.model';
import { EventService } from 'src/app/services/event.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})

export class AddEventComponent implements OnInit {
  isEditing: boolean = false;
  eventForm: FormGroup;
  minDateTime: string;
  eventId: string | null = null;

  constructor(private formBuilder: FormBuilder, private eventService: EventService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.eventForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      location: ['', Validators.required],
      dateTime: ['', [Validators.required, this.dateTimeValidator]],
      imageUrl: ['', Validators.required]
    });
    // Set minimum date to tomorrow
    const tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);
    this.minDateTime = tomorrow.toISOString().slice(0, 16); // Format to YYYY-MM-DDTHH:MM 
  }

  ngOnInit(): void {
    this.eventId = this.route.snapshot.paramMap.get('id');
    if (this.eventId) {
      this.isEditing = true;
      this.loadEvent(this.eventId);
    }
  }

  loadEvent(eventId: string): void {
    this.eventService.getEventById(eventId).subscribe(event => {
      this.eventForm.patchValue(event);
    });
  }

  dateTimeValidator(control: any) {
    const date = new Date(control.value);
    return isNaN(date.getTime()) ? { invalidDate: true } : null;
  }

  onSubmit(): void {
    if (this.eventForm.valid) {
      if (this.isEditing && this.eventId != null) {
        const updatedEvent = { ...this.eventForm.value }; // Add ID to the updated event
        this.eventService.updateEvent(updatedEvent, this.eventId).subscribe(() => {
          Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Event Updated Successfully!!!",
            showConfirmButton: false,
            timer: 1500, 
            toast:true,
          });
          this.router.navigate(['/organizer', 'home'])
        });
      } else {
        const eventData: EventCreateRequest = this.eventForm.value;
        this.eventService.addNewEvent(eventData).subscribe({
          next: (resp) => {
            Swal.fire({
              position: "top-end",
              icon: "success",
              title: "Event Added Successfully!!",
              showConfirmButton: false,
              timer: 1500, 
              toast:true,
            });
            this.router.navigate(['/organizer', 'home'])
          },
          error: (err) => console.log(err)
        })
      }
    } else {
      console.log('Form is invalid');
    }


  }
}


