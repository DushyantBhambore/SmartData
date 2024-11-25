import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserDto } from '../../Model/userdto';
import { AuthService } from '../../Service/auth.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router'; // Import ActivatedRoute


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent  implements OnInit {

  userObj : UserDto ={
    userId: 0,
    role: '',
    userName: '',
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    country: '',
    state: '',
    city: '',
    isActive: false,
    isDelete: false
  };
  
  constructor() { }

  service = inject(AuthService);
  route = inject(ActivatedRoute);
  router = inject(Router)
  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      const userId = params['userId'];
      if (userId) {
        this.fetchUserDetails(userId); // Fetch user data for editing
      }
    });
  }
  fetchUserDetails(userId: number) {
    this.service.getbyid(userId).subscribe({
      next: (res:any) => {
        this.userObj = res; // Populate form with user details
      },
      error: (err) => {
        console.error('Error fetching user details', err);
      },
    });
  }

  
  onSubmit() {

    if (this.userObj.userId > 0) {
      // Update user
      this.service.updateuser(this.userObj).subscribe({
        next: (res) => {
          alert('User updated successfully');
          this.router.navigateByUrl("/user");
          
        },
        error: (err) => {
          console.error('Error updating user', err);
          alert('Failed to update user');
        },
      });
    } else {
      // Add new user
      this.service.getregister(this.userObj).subscribe({
        next: (res) => {
          alert('User registered successfully');
          this.router.navigateByUrl("/login")
        },
        error: (err) => {
          console.error('Error registering user', err);
          alert('Failed to register user');
        },
      });
    }

}

}

