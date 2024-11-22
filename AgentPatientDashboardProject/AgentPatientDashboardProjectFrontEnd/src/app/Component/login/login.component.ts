import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import {FormsModule} from '@angular/forms'
import { LoginService } from '../../Service/login.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
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
    this.service.getLogin(this.userObj).subscribe({
      next:(res:any)=>{
        console.log(res);
          localStorage.setItem('logindata', JSON.stringify(res))

          const expiry = new Date(res.expiry)
          localStorage.setItem('expiry', expiry.toISOString())
          // localStorage.setItem('token', res.token)
          alert('Login Successfully');
          this.router.navigateByUrl('patient')
      },
      error:(error)=>{
        alert('I am error in login ')
        console.log(error)
      }
    })
  }


}
