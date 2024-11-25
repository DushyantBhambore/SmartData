import { Component, inject, OnInit } from '@angular/core';
import { AdminService } from '../../Service/admin.service';
import { UserDto } from '../../Model/userdto';
import { JsonPipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css',
})
export class UserComponent implements OnInit {
  userlist: any;
  service = inject(AdminService);
  router = inject(Router)

  constructor() {}

  ngOnInit(): void {
    this.onget();
  }

  // get all User
  onget() {
    this.service.getalluser().subscribe({
      next: (res) => {
        debugger;
        console.log(res);
        this.userlist = res;
      },
      error: (error) => {
        console.log('I am error in get');
      },
    });
  }

  // Navigate to Edit User
  onEdit(id: number) {
    this.router.navigate(['/register'], { queryParams: { userId: id } });
  }
  // Delete Patient
  ondelete(id: number) {
    const data = confirm('Are you sure do you want delete this Id ');
    if (data) {
      debugger
      this.service.deleteuser(id).subscribe({
        next: (res) => {
          console.log('deleted');
          alert('delete successfully ');
          this.onget();
          window.location.reload();
        },
        error: (error) => {
          console.log('I am error in delete');
        },
      });
    }
  }
}
