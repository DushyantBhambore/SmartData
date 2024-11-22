import { HttpClient } from '@angular/common/http';
import { Inject, inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  loginurl ='https://localhost:7062/api/User/login'

  

  registerurl = ''

  http = inject(HttpClient)


  loginservice(data:any){
    return this.http.post(this.loginurl,data)
  }
  constructor() { }
}
