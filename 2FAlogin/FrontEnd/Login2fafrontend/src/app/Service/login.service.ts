import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  registerurl = 'https://localhost:7276/api/User/register'
  loginurl ='https://localhost:7276/api/User/login'

  verifyurl ='https://localhost:7276/api/User/VerifyOtp'


  http = inject(HttpClient)

  constructor() { }


  getlogin (data:any)
  {
    return this.http.post(this.loginurl,data)
  }

  getverify (data:any)
  {
    return this.http.post(this.verifyurl,data)
  }
}
