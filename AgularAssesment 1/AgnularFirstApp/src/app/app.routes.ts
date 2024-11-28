import { Routes } from '@angular/router';
import { LayoutComponent } from './Component/layout/layout.component';
import { ChildComponemtComponent } from './Component/child-componemt/child-componemt.component';
import { DatabindingComponent } from './Component/databinding/databinding.component';
import { EmployeeComponent } from './Component/employee/employee.component';
import { ReactiveFormsComponent } from './Component/reactive-forms/reactive-forms.component';
import { TemplateFormsComponent } from './Component/template-forms/template-forms.component';
import { SVGComponent } from './Component/svg/svg.component';
import { FormArrayComponent } from './Component/form-array/form-array.component';

export const routes: Routes = [
    {
        path:'',
        component:LayoutComponent,
        children:[
            {
                path:'child',
                component:ChildComponemtComponent
            },
            {
                path:'databindng',
                component:DatabindingComponent
            },
            {
                path:'employee',
                component:EmployeeComponent
            },
            {
                path:'reactiveform',
                component:ReactiveFormsComponent
            },
            {
                path:'templateform',
                component:TemplateFormsComponent
            },
            {
                path:'svg',
                component:SVGComponent
            },
            {
                path:'formarray',
                component:FormArrayComponent
            }
        ]
    },
    
];
