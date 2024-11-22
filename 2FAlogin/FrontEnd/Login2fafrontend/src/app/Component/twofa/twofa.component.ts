import { Component, inject } from '@angular/core';
import { LoginService } from '../../Service/login.service';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-twofa',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './twofa.component.html',
  styleUrl: './twofa.component.css'
})
export class TwofaComponent {

  userObj ={
    email :'',
    otp :''
  }

  service = inject(LoginService)
  route = inject(Router)

  onVerify()
  {
    debugger
    this.service.getverify(this.userObj).subscribe((res:any)=>{
      console.log(res);
      localStorage.setItem('token',res.token)
      alert('Login Successfully')
      this.route.navigateByUrl('zoom')
    })
  }

}
