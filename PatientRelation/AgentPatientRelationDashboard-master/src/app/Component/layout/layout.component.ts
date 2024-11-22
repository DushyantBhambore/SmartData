import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterLink,RouterOutlet],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

  loaddata : any 

  email :string =''
  firstname :string =''

  
  router = inject(Router)
  constructor(){
    const loginuser =  localStorage.getItem('logindata')
    if(loginuser !=null)
    {
      this.loaddata = JSON.parse(loginuser);
      this.email= this.loaddata.Email;
      this.firstname = this.loaddata.FirstName
    }

  }

  onLogOut(){

    localStorage.removeItem('logindata');
    this.router.navigateByUrl('login');
  }

}
