import { Routes } from '@angular/router';
import { LayoutComponent } from './Component/layout/layout.component';
import { CounterComponent } from './Component/counter/counter.component';
import { RegisterComponent } from './Component/register/register.component';
import { CartComponent } from './Component/cart/cart.component';
import { ProductsComponent } from './Component/products/products.component';
import { ECartandbillComponent } from './Component/e-cartandbill/e-cartandbill.component';
import { EleectronicsdashboardComponent } from './Component/eleectronicsdashboard/eleectronicsdashboard.component';

export const routes: Routes = [
    {
        path :'',
        redirectTo :'login',
        pathMatch :'full'
    },
    {
        path:'',
        component:LayoutComponent,
        children:[
            {
                path:'counter',
                component:CounterComponent
            },
            {
                path:'cart',
                component:CartComponent
            },
            {
                path:'product',
                component:ProductsComponent
            },
            {
                path:'ecart',
                component:ECartandbillComponent
            },
            {
                path:'electroniscdashboard',
                component:EleectronicsdashboardComponent
            }
            
        ]
    },
    {
        path:'register',
        component:RegisterComponent
    }

    
];
