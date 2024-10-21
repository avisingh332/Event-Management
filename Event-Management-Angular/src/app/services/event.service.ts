import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { AttendeeEventResponseType, OrganizerEventResponseType } from '../models/response.model';
import { EventCreateRequest } from '../models/request.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EventService  {

  constructor(private http:HttpClient) { }
  baseApiUrl = environment.API_URL;
  
  getAllAttendeeEvents(){
    return this.http.get<AttendeeEventResponseType[]>(`${this.baseApiUrl}/api/Event/Attendee`);
  }
  getAllOrganizerEvents(){
    return this.http.get<OrganizerEventResponseType[]>(`${this.baseApiUrl}/api/Event/Organizer`);
  }

  addNewEvent(event:EventCreateRequest){
    return this.http.post<string>(`${this.baseApiUrl}/api/Event`, event);
  }

  getEventById(id: string){
    return this.http.get<AttendeeEventResponseType>(`${this.baseApiUrl}/api/Event/${id}`);
  }
  updateEvent(event: EventCreateRequest, id:string){
    return this.http.put<OrganizerEventResponseType>(`${this.baseApiUrl}/api/Event/${id}`, event);
  }
  deleteEvent(id:string){
    return this.http.delete<string>(`${this.baseApiUrl}/api/Event/${id}`);
  }
  registerEvent(eventId:string):Observable<string>{
    return  this.http.post<string>(`${this.baseApiUrl}/api/Event/${eventId}/register`, {});
  }
  cancelEventRegistration(eventId:string):Observable<string>{
    return this.http.delete<string>(`${this.baseApiUrl}/api/Event/my-registration/${eventId}`,)
  }
}
