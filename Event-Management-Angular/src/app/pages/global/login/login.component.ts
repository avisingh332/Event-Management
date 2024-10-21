import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginResponse } from 'src/app/models/response.model';
import { AuthService } from 'src/app/services/auth.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formModel:FormGroup;
  constructor(private authService: AuthService, private fb:FormBuilder, private router:Router,
              private route:ActivatedRoute
  ) {
    this.formModel=this.fb.group({
      Email:['',Validators.compose([Validators.required,Validators.email])],
      Password:['',Validators.compose([Validators.required,Validators.nullValidator])]
    })
  }

  ngOnInit(): void {
    
  }

  onSubmit(){
    this.authService.login(this.formModel.value).subscribe({
      next:(response:LoginResponse)=>{

        this.authService.setUser({
          email: response.email,
          roles: response.roles,
          name: response.name,
          token : response.jwtToken, 
        });
        let redirectUrl = this.authService.redirectUrl  || "/";
        this.router.navigate([redirectUrl]);
        // if(response.roles.includes('Organizer')){
        //   Swal.fire({
        //     position: "top-end",
        //     icon: "success",
        //     title: "User Logged In Successfully!!",
        //     showConfirmButton: false,
        //     timer: 1500, 
        //     toast:true,
        //   });
        //   this.router.navigateByUrl('/organizer/home')
        // }
        // else{
        //   this.router.navigateByUrl('/user/home')
        // }
      },
      error:(err)=>{
        console.log(err);
        Swal.fire({
          icon: "error",
          position:'top-right',
          text: "Incorrect Credentials!",
          toast: true, 
          showConfirmButton: false,
          timer:1500,
        });
      }
    });
    
  }

 
}
