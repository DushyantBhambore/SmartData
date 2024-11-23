import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { LoginComponent } from './Component/login/login.component';
import { LayoutComponent } from './Component/layout/layout.component';
import { RegisterComponent } from './Component/register/register.component';
import { SignaRComponent } from './Component/signa-r/signa-r.component';

export const routes: Routes = [
    {
        path:'',
        redirectTo:'login',
        pathMatch:'full'
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
                path:'signalR',
                component:SignaRComponent
            }
        ]
    },
    {
        path:'register',
        component:RegisterComponent
    }
];
