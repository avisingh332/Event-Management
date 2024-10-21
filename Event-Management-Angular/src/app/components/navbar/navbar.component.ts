import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/generic.model';
import { AuthService } from 'src/app/services/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  user:User|undefined;

  constructor(private authService: AuthService, private router:Router, private fb:FormBuilder) {
  
  }
  isAdmin():boolean{
    if(this.user && this.user?.roles.includes('Admin')){
      return true;
    }
    return false;
  }
  ngOnInit(): void {
    this.authService.user$().subscribe(user=>{
      this.user = user;
    });
  }

  logout(){
    this.authService.logout();
    Swal.fire({
      position: "top-end",
      icon: "success",
      title: "Logged Out Successfully!!",
      showConfirmButton: false,
      timer: 1500, 
      toast:true,
    });
    this.navigateToHome();
  }

  navigateToHome() {
    const targetPath = '/user/home';
    const currentPath = this.router.url; // Get the current URL path
    console.log("Target path", targetPath);
    console.log("Current path", currentPath);
    if (currentPath === targetPath) {
      // If the current path matches the target path, reload the page
      window.location.reload();
    } else {
      // Otherwise, navigate to the target path
      this.router.navigateByUrl(targetPath);
    }
  }
}
