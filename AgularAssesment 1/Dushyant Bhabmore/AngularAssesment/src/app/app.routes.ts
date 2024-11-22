import { Routes } from '@angular/router';
import { EmployeeComponent } from './Cmmponent/employee/employee.component';
import { CustomerComponent } from './Cmmponent/customer/customer.component';
import { PateintComponent } from './Cmmponent/pateint/pateint.component';


export const routes: Routes = [
  {
    path:'employee',
    component:EmployeeComponent
  },
  {
    path:'customer',
    component:CustomerComponent
  },
  {
    path:'pateint',
    component:PateintComponent
  }
];
