import { Component, inject } from '@angular/core';
import { AuthService } from '../../Service/auth.service';
import { LoginDto } from '../../Model/logindto';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  userObj : LoginDto ={
    role: '',
    email: '',
    password: ''
  }
  service = inject(AuthService);

  router = inject(Router)

  onLogin(){
    debugger
    this.service.getlogin(this.userObj).subscribe({
      next: (res)=>{
        console.log(res);
        alert("Login Successful");
        localStorage.setItem('token', res.token);
        localStorage.setItem('logindata',JSON.stringify(res.logindata))
        localStorage.setItem('role',res.data);
        this.router.navigateByUrl('profile')
      },
      error: (err)=>{
        console.log(err);
        alert("Login Failed");
      }
    })
  }

}
