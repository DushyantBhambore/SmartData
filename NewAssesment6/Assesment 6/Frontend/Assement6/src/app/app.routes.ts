import { Routes } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { LayoutComponent } from './Component/layout/layout.component';
import { RegisterComponent } from './Component/register/register.component';
import { ChatHubComponent } from './Component/chat-hub/chat-hub.component';
import { ProfileComponent } from './Component/profile/profile.component';
import { UserComponent } from './Component/user/user.component';
import { authGuard } from './Guard/auth.guard';

export const routes: Routes = [
    {
        path:'',
        redirectTo : 'login',
        pathMatch : 'full',
    },
    {
        path:'login',
        component:LoginComponent
    },
    {
        path:'',
        component:LayoutComponent,
        children:[
            {
                path:'chathub',
                component:ChatHubComponent,
              
            },
            {
                path:'profile',
                component:ProfileComponent,
                
            },
            {
                path:'user',
                component:UserComponent,
                canActivate:[authGuard]
            }
        ]
    },
    {
        path:'register',
        component:RegisterComponent
    }

];
