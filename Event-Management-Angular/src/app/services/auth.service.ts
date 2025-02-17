import { Injectable } from '@angular/core';
import { User } from '../models/generic.model';
import { environment } from '../environment/environment';
import { BehaviorSubject, catchError, map, Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from '../models/response.model';
import { LoginRequest } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private user = new BehaviorSubject<User|undefined>(undefined);
  redirectUrl:string|null =null;
  baseApiUrl = environment.API_URL;

  constructor(private http:HttpClient) {
    var user = this.getUser();
    if(user!=undefined){
      this.setUser(user);
    }
  }

  user$():Observable<User|undefined>{
    return this.user.asObservable();
  }

  setUser(user: User): void {

    this.user.next(user);

    localStorage.setItem('user-email', user.email);
    localStorage.setItem('user-roles', user.roles.join(','));
    localStorage.setItem('name', user.name);
    localStorage.setItem('token', user.token);
  }

  getUser(): User | undefined {
    const email = localStorage.getItem('user-email'); 
    const roles = localStorage.getItem('user-roles'); 
    const name = localStorage.getItem('name');
    const token = localStorage.getItem('token');

    if(email && roles && name && token){
      const user : User = {
        email: email,
        roles: roles.split(','),
        name: name,
        token : token,
      };

      return user;
    }
    return undefined;
  }
 
 

  login(loginDetail: LoginRequest): Observable<LoginResponse>{
    return this.http.post<any>(`${this.baseApiUrl}/api/Auth/Login`, loginDetail);
  }

  logout(): void {
    localStorage.clear();
    this.user.next(undefined);
  }
}
