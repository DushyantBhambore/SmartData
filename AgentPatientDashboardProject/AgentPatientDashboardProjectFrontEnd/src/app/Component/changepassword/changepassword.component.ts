import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../../Service/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-changepassword',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './changepassword.component.html',
  styleUrl: './changepassword.component.css'
})
export class ChangepasswordComponent {
  userObj ={
    agentId :'',
    newPassword :'',
    newConfirmPassword:''
  }


  service = inject(LoginService)
  router = inject(Router)

  constructor(){}

  onLogin(){
    this.service.getChangePassword(this.userObj).subscribe({
      next:(res:any)=>{
        console.log(res);
          // localStorage.setItem('token', res.token)
          alert('Password Changed  Successfully');
          this.router.navigateByUrl('patient')
       
      },
      error:(error:any)=>{
        alert('I am error in login ')
        console.log(error)
      }
    })
  }

}
