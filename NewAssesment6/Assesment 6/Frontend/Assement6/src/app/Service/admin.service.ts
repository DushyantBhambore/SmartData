import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { UserDto } from '../Model/userdto';

@Injectable({
  providedIn: 'root'
})
export class AdminService {


  deleteurl = 'https://localhost:7178/api/Admin/DeleteUser'
  geturl = 'https://localhost:7178/api/Admin/GetAllUser'

  http = inject(HttpClient)

  constructor() { }


  getalluser()
  {
    return this.http.get<UserDto>(this.geturl)
  }

  deleteuser(id:number)
  {
    return this.http.delete(this.deleteurl+"/"+id)
  }

  
}
