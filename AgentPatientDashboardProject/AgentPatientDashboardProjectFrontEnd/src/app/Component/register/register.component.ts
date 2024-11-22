import { Component, inject } from '@angular/core';
import { LoginService } from '../../Service/login.service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  userObj ={
    firstName :'',
    lastName :'',
    email :'',
    password :'',
    confirmPassword:''
  }

 
  service = inject(LoginService)
  router = inject(Router)

  constructor(){}

  onLogin(){
    this.service.getRegister(this.userObj).subscribe({
      next:(res:any)=>{
        console.log(res);
          // localStorage.setItem('token', res.token)
          alert('Register Successfully');
          this.router.navigateByUrl('login')
       
      },
      error:(error)=>{
        alert('I am error in login ')
        console.log(error)
      }
    })
  }


}
