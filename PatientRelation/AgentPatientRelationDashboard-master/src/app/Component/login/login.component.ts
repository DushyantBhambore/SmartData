import { Component, inject, Inject } from '@angular/core';
import { LoginService } from '../../Service/login.service';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  userObj ={
    email :'',
    password :''
  }

  service = inject(LoginService)
  router = inject(Router)

  constructor(){}

  onLogin(){
    this.service.loginservice(this.userObj).subscribe({
      next:(res:any)=>{
        console.log(res);
        if(res.success){
          localStorage.setItem('logindata', JSON.stringify(res.user))
          localStorage.setItem('token', res.token)
          alert('Login Successfully');
          this.router.navigateByUrl('patient')
        }
       
      },
      error:(error)=>{
        alert('I am error in login ')
      }
    })
  }

}
