import { Component, inject, OnInit } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterLink,RouterOutlet],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit{
  loaddata : any 

  router = inject(Router)
  constructor(){
    const loginuser =  localStorage.getItem('logindata')
    if(loginuser !=null)
    {
      this.loaddata = JSON.parse(loginuser);
    }

  }
  ngOnInit(): void {

    this.checkTokenExpiry();
  }

  
  checkTokenExpiry() {
    const expiryTime = localStorage.getItem('expiry');
    
    if (expiryTime) {
      const expireIn = new Date(expiryTime);  
      const currentTime = new Date();  

      if (currentTime >= expireIn) {
        this.onLogOut(); 
      } else {
        
        const timeRemaining = expireIn.getTime() - currentTime.getTime();
        setTimeout(() => {
          this.onLogOut(); 
        }, timeRemaining);
      }
    } else {  
      this.onLogOut();
    }
  }


  onLogOut(){

    localStorage.removeItem('logindata');
    this.router.navigateByUrl('login');
  }

}
