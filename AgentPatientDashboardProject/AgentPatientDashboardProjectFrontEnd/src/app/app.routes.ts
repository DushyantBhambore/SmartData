import { Routes } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { RegisterComponent } from './Component/register/register.component';
import { ForgotpasswordComponent } from './Component/forgotpassword/forgotpassword.component';
import { PatientComponent } from './Component/patient/patient.component';
import { ChangepasswordComponent } from './Component/changepassword/changepassword.component';
import { LayoutComponent } from './Component/layout/layout.component';
import { loginGuard } from './Guard/login.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'forgot-password',
    component: ForgotpasswordComponent,
  },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'patient',
        component: PatientComponent,
        canActivate:[loginGuard]
      },
      {
        path: 'change-password',
        component: ChangepasswordComponent,
        canActivate:[loginGuard]
      },
    ],
  },
];
