import { Component, OnInit } from '@angular/core';
import { UserDto } from '../../Model/userdto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css'
})
export class ProfileComponent implements OnInit{
  
  userdata = JSON.parse(localStorage.getItem('logindata')!);

  constructor(){
    console.log(this.userdata);
  }

  ngOnInit(): void {
    this.userdata;
  }
  

}
