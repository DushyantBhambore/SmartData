import { Routes } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { RegisterComponent } from './Component/register/register.component';
import { LayoutComponent } from './Component/layout/layout.component';
import { TwofaComponent } from './Component/twofa/twofa.component';
import { OpenTokComponent } from './Component/open-tok/open-tok.component';
import { ZoomComponent } from './Component/zoom/zoom.component';

export const routes: Routes = [
    {
        path:'',
        redirectTo:'login',
        pathMatch:'full'
    },
    {
        path:'login',
        component: LoginComponent
    },
    {
        path:'register',
        component:RegisterComponent
    },
    {
        path:'',
        component:LayoutComponent,
        children:[
            {
                path:'verify',
                component:TwofaComponent
            },
            {
                path:'opentok',
                component:OpenTokComponent
            },
            {
                path:'zoom',
                component:ZoomComponent
            }


        ]
    }
];
