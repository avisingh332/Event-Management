import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/global/login/login.component';
import { OrganizerHomeComponent } from './pages/organizer/organizer-home/organizer-home.component';
import { UserHomeComponent } from './pages/user/user-home/user-home.component';
import { AddEventComponent } from './pages/organizer/add-event/add-event.component';
import { EventDetailsComponent } from './pages/user/event-details/event-details.component';
import { MyBookingsComponent } from './pages/user/my-bookings/my-bookings.component';
import { NotFoundComponent } from './pages/global/not-found/not-found.component';
import { authGuard, HomePathRedirection } from './guards/auth.guard';

const routes: Routes = [
  // {path:'',   canActivate:[HomePathRedirection], redirectTo:'user/home', pathMatch:'full'},
  {path:'', canActivate:[HomePathRedirection], component:UserHomeComponent, pathMatch:'full'},
  {path:'not-found', component: NotFoundComponent},
  {path:'login', component:LoginComponent, canActivate:[HomePathRedirection]},
  {path:'organizer', canActivate:[authGuard],  children:[
    {path:'home', component:OrganizerHomeComponent},
    {path:'add-event', component:AddEventComponent},
    {path:'update-event/:id', component:AddEventComponent},
  ]}, 
  {path:'event-details/:id', component:EventDetailsComponent},
  {path:'user', redirectTo:'user/home', pathMatch:'full'},
  {path:'user',  children:[
    {path:'home', component:UserHomeComponent},
    
    {path:'my-bookings', component:MyBookingsComponent}
  ]},
  {path:'**', redirectTo: '/not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
