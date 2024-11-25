import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { LoginDto } from '../Model/logindto';
import { RegisterDto } from '../Model/registerdto';
import { LoginResponse } from '../Model/LoginResponse';
import { UserDto } from '../Model/userdto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  registerusrl = 'https://localhost:7178/api/Authenticate/Register'

  loginurl ='https://localhost:7178/api/Authenticate/Login'

  updateurl ='https://localhost:7178/api/Admin/UpdateUser'

  getbyidurl ='https://localhost:7178/api/Authenticate/GetUserById'

  http = inject(HttpClient)
  constructor() { }

  getlogin(data:LoginDto)
  {
    return this.http.post<LoginResponse>(this.loginurl,data)
  }
  getregister(data:RegisterDto)
  {
    return this.http.post(this.registerusrl,data)
  }
  getbyid(id:number)
  {
    return this.http.get(this.getbyidurl+"/"+id)
  }
  updateuser(data:UserDto)
  {
    return this.http.put(this.updateurl,data)
  }
}
