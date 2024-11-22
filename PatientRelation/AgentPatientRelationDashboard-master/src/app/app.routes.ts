import { Routes } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { LayoutComponent } from './Component/layout/layout.component';
import { PatientComponent } from './Component/patient/patient.component';
import { AddUpdatePatientComponent } from './Component/add-update-patient/add-update-patient.component';

export const routes: Routes = [
    {
        path : '',
        redirectTo :'login',
        pathMatch:'full'
    },
    {
        path:'login',
        component:LoginComponent
    },
    {
        path :'',
        component:LayoutComponent,
        children:[
            {
                path:'patient',
                component:PatientComponent
            },
            {
                path:'add-update',
                component:AddUpdatePatientComponent
            }
        ]
    }
];
