import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

   loginurl = 'https://localhost:7010/api/User/Login'
  forgotpasswordurl = 'https://localhost:7010/api/User/ForgotPassword'
 changepasswordurl ='https://localhost:7010/api/User/ChangePassword'
 registerurl ='https://localhost:7010/api/User/AddUser'


  http = inject(HttpClient)
  constructor() { }


  getLogin(data:any){
    return this.http.post(this.loginurl,data)
  }

  getForgotPassword(data:any){
    return this.http.post(this.forgotpasswordurl,data)
  }
  getChangePassword(data:any){
    return this.http.post(this.changepasswordurl,data)
  }
  getRegister(data:any){
    return this.http.post(this.registerurl,data)
  }
}
