import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OrganizerEventResponseType } from 'src/app/models/response.model';
import { EventService } from 'src/app/services/event.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-organizer-home',
  templateUrl: './organizer-home.component.html',
  styleUrls: ['./organizer-home.component.css']
})
export class OrganizerHomeComponent {
  events: OrganizerEventResponseType[] = [];
  constructor(private router: Router, private eventService: EventService) {
  }
  handleDelete($event: any) {
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    }).then((result) => {
      if (result.isConfirmed) {
        this.eventService.deleteEvent($event.id).subscribe({
          next:(resp)=>{
            console.log(resp);
            Swal.fire({
              title: "Deleted!",
              text: "Your file has been deleted.",
              icon: "success"
            }).then(()=>{
              this.loadEvent();
            });
          }, 
          error:(err)=>{
            console.log(err);
          }
        })
        
      }
    });
  }
  ngOnInit(): void {
    this.loadEvent();
  }

  loadEvent(){
    this.eventService.getAllOrganizerEvents().subscribe({
      next: (resp) => {
        this.events = resp;
      },
      error: (err) => {
        console.log(err);
        // alert("There is Some Error while Fetching!!!!");
      }
    })
  }
}
