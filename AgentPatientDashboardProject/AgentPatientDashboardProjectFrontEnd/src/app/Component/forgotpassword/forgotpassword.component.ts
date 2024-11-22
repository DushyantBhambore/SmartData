import { Component, inject } from '@angular/core';
import { LoginService } from '../../Service/login.service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-forgotpassword',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterLink],
  templateUrl: './forgotpassword.component.html',
  styleUrl: './forgotpassword.component.css'
})
export class ForgotpasswordComponent {
  
  userObj ={
    email :'',
    newPassword :'',
    newConfirmPassword:''
  }



  service = inject(LoginService)
  router = inject(Router)

  constructor(){}

  onLogin(){
    this.service.getForgotPassword(this.userObj).subscribe({
      next:(res:any)=>{
        console.log(res);
          alert('Forgot Password Successfully');
          this.router.navigateByUrl('login')
       
      },
      error:(error:any)=>{
        alert('I am error in login ')
        console.log(error)
      }
    })
  }

}
