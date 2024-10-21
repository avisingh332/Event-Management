import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/generic.model';
import { AttendeeEventResponseType } from 'src/app/models/response.model';
import { AuthService } from 'src/app/services/auth.service';
import { EventService } from 'src/app/services/event.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent implements OnInit {

  user: User | undefined;
  eventId: string = "";
  event$: Observable<AttendeeEventResponseType> | undefined;

  constructor(private router: Router, private route: ActivatedRoute,
    private eventService: EventService, private authService: AuthService
  ) { }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        let id = params.get('id');
        if (id != null) {
          this.eventId = id;
          this.event$ = this.eventService.getEventById(id);
          this.loadUser();
        }
      },
    });
  }
  loadUser() {
    this.authService.user$().subscribe({
      next: (user) => {
        this.user = user;
      }
    })
  }

  handleCancelRegistration() {
    Swal.fire({
      title: "Are you sure to cancel Registration?",
      text: "",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#008000",
      cancelButtonColor: "#d33",
      confirmButtonText: "Confirm!"
    }).then((result) => {
      if (result.isConfirmed) {
        this.eventService.cancelEventRegistration(this.eventId).subscribe({
          next: (resp: any) => {
            Swal.fire({
              position: "top-end",
              icon: "success",
              title: resp.message,
              showConfirmButton: false,
              timer: 1500,
              toast: true,
            });
            this.event$ = this.eventService.getEventById(this.eventId);
          },
          error: (err) => {
            console.log(err);
          }
        })

      }
    });
  }

  registerEvent(): void {
    //-------- Divert to login if not logged In"-----------
    if (this.user == undefined) {
      this.authService.redirectUrl = this.router.url;
      this.router.navigate(['/login']);
      Swal.fire({
        position: "top-end",
        icon: "info",
        toast: true,
        title: "Login To Register",
        showConfirmButton: false,
        timer: 1500
      });
      return;
    }
    // ----- Else Proceed-------------
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
        this.eventService.registerEvent(this.eventId).subscribe({
          next: (resp: any) => {
            Swal.fire({
              position: "top-end",
              icon: "success",
              title: resp.message,
              showConfirmButton: false,
              timer: 1500,
              toast: true,
            });
            this.event$ = this.eventService.getEventById(this.eventId);
          },
          error: (err) => {
            console.log(err);
          }
        })

      }
    });
  }

  // refreshPage() {
  //   // Refresh the current route to reload the page content
  //   this.router.navigate([this.router.url])
  //     .then(() => {
  //       window.location.reload();
  //     });
  // }
}
