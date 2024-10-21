import { Injectable, OnInit } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { User } from '../models/generic.model';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    
    constructor(private authService: AuthService) { }
    
    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    //    console.log("Intercepted The request");
       const user:User|undefined = this.authService.getUser();
        if (user && user.token ) {
            const clonedRequest = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${user.token}`
                }
            });

            // console.log('Modified Request with Token:', clonedRequest);

            return next.handle(clonedRequest);
        }

        return next.handle(request);
    }
}