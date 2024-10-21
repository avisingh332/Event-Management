import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { EventResponseVm, User } from 'src/app/models/generic.model';
import { AttendeeEventResponseType, OrganizerEventResponseType } from 'src/app/models/response.model';
import { AuthService } from 'src/app/services/auth.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})

export class HomeComponent implements OnInit, OnChanges {


  @Input() events: OrganizerEventResponseType[] | AttendeeEventResponseType[]  =[];
  eventsVm: EventResponseVm[] =[];
  @Input() role: string|undefined; 
  @Output() delete = new EventEmitter<any>();
  @Output() register = new EventEmitter<any>();

  user:User|undefined;
 
  constructor(private authService:AuthService, private router:Router) {}

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['events'] && this.events) {
      this.eventsVm = this.events.map(event => {
        const isAttendeeEvent = 'isRegistered' in event;
        return {
          id: event.id,
          name: event.name,
          description: event.description,
          location: event.location,
          dateTime: event.dateTime,
          createdAt: event.createdAt,
          organizerId: event.organizerId,
          organizer: event.organizer,
          imageUrl: event.imageUrl,
          isRegistered: isAttendeeEvent ? (event as AttendeeEventResponseType).isRegistered : false,
          attendees: 'attendees' in event ? (event as OrganizerEventResponseType).attendees: null,
          toggleGuestList: false,
        } as EventResponseVm;
      });
    }
  }

  ngOnInit(): void {
    this.authService.user$().subscribe(user=>{
      this.user = user;
    });
  }
  isEventRegistered(event:any):boolean{
    return (this.role ==="Attendee" && (event as AttendeeEventResponseType).isRegistered)
  }

  registerEvent(event: any):void {
    if(this.user ==undefined){
      this.router.navigate(['/login']);
      Swal.fire({
        position: "top-end",
        icon: "info",
        toast:true,
        title: "Login To Register",
        showConfirmButton: false,
        timer: 1500
      });
      return;
    }
    this.register.emit(event); // Emit the register event with the event data
  }

  deleteEvent(event: any) {
    this.delete.emit(event); // Emit the delete event with the event data
  }
  guestListToggle(eventId:string) {
    let idx = this.eventsVm.findIndex(ev=> ev.id ==eventId);
    console.log("Event is ",this.eventsVm[idx]);
    this.eventsVm[idx].toggleGuestList= !this.eventsVm[idx].toggleGuestList;
  }
}
