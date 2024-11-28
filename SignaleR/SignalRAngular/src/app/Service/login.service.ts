import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { IUserDto } from '../Component/Model/UserDto';
import { IVerifyOTP } from '../Component/Model/VerifuOTP';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  
  apiurl ='https://localhost:7265/api/Agent'

  loginurl ='https://localhost:7265/api/User/login'

  verifyotopurl ='https://localhost:7265/api/User/VerifyOtp'

  http  = inject(HttpClient)

  constructor() { }


  onlogin(data:IUserDto)
  {
    this.http.post<IUserDto>(this.loginurl,data)
  }
  onverifyotp(data:IVerifyOTP)
  {
    this.http.post<IVerifyOTP>(this.verifyotopurl,data)
  }




}
