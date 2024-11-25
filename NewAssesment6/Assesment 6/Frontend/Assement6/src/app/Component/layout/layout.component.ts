import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet,RouterLink,CommonModule],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {

  userRole : string ='';
  loaddata : any 

  /**
   * Initializes the component by retrieving the user role from local storage.
   * If there is no user role stored, the component will default to an empty string.
   */
  constructor(){
    
    this.userRole = localStorage.getItem('role') || '';
  }
  router= inject(Router)
  onLogOut(){

    localStorage.removeItem('logindata');
    this.router.navigateByUrl('login');
  }

}
