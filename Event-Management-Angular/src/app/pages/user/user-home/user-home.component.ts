import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AttendeeEventResponseType } from 'src/app/models/response.model';
import { AuthService } from 'src/app/services/auth.service';
import { EventService } from 'src/app/services/event.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})
export class UserHomeComponent implements OnInit {
 

  events: AttendeeEventResponseType[] = [];
  constructor(private router: Router, private eventService: EventService) {
  }

  loadEvents(){
    this.eventService.getAllAttendeeEvents().subscribe({
      next: (resp: AttendeeEventResponseType[]) => {
        resp.forEach(element => {
          element.description = this.trimString(element.description);
        });
        this.events = resp;
      },
      error: (err) => {
        console.log(err);
        alert("There is Some Error while Fetching!!!!");
      }
    })
  }

  ngOnInit(): void {
    this.loadEvents();
  }

  register($event: any) {
    // register for event 
    Swal.fire({
      title: "Are you sure to register?",
      text: "confirm to register",
      icon: "question",
      showCancelButton: true,
      confirmButtonColor: "#008000",
      cancelButtonColor: "#d33",
      confirmButtonText: "Register!"
    }).then((result) => {
      if (result.isConfirmed) {
        this.eventService.registerEvent($event.id).subscribe({
          next:(resp:string)=>{
            Swal.fire({
              position: "top-end",
              icon: "success",
              title: resp,
              showConfirmButton: false,
              timer: 1500
            });
          }, 
          error:(err)=>{
            console.log(err);
          }
        })
        Swal.fire({
          title: "Registered!",
          text: "Your have registered for the event",
          icon: "success"
        });
        this.loadEvents();
      }
    });
  }

  trimString(str:string){
    const words = str.split(' ');
    const trimmedString = words.slice(0, 8).join(' ') + "....";
    return trimmedString;
  }
}
