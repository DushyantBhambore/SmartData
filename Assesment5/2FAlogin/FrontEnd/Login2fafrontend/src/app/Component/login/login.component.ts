import { Component, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginService } from '../../Service/login.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  userObj = {
    email :'',
    password:''
  }

  route = inject(Router)
  service = inject(LoginService)

  constructor() { }

  onLogin()
  {
    debugger
    this.service.getlogin(this.userObj).subscribe((res:any)=>{
      console.log(res);
      alert('Opt sent to your email')
      this.route.navigateByUrl('verify')
    })
  }




}
