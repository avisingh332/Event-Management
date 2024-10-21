import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './pages/global/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { OrganizerHomeComponent } from './pages/organizer/organizer-home/organizer-home.component';
import { HomeComponent } from './components/home/home.component';
import { UserHomeComponent } from './pages/user/user-home/user-home.component';
import { AuthInterceptor } from './interceptor/auth.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent, NavbarComponent, OrganizerHomeComponent,
    HomeComponent, UserHomeComponent,
    AddEventComponent,
    EventDetailsComponent,
    TimeFormatPipe,
    MyBookingsComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  exports: [
    TimeFormatPipe
  ],
  bootstrap: [AppComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
})
export class AppModule { } import { AddEventComponent } from './pages/organizer/add-event/add-event.component';
import { NotFoundComponent } from './pages/global/not-found/not-found.component';
import { EventDetailsComponent } from './pages/user/event-details/event-details.component';
import { TimeFormatPipe } from './pipes/time-format.pipe';
import { MyBookingsComponent } from './pages/user/my-bookings/my-bookings.component';


