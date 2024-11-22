import { Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import {  FormsModule } from '@angular/forms';
import { EmployeeServiceService } from '../../Services/employee-service.service';
@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterOutlet,RouterLink,FormsModule],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent {
  
  componentchange :string=''

  service = inject(EmployeeServiceService)

  onChange(value : string)
  {
    this.service.onchange.next(value);

  }



}
