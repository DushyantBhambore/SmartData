import { employee } from './../Model/employee';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

  private apiUrl = 'http://localhost:5054/GetEmployeeList'

  private posturl = 'http://localhost:5054/AddEmployee'

  private puturl ='http://localhost:5054/UpdateEmployee'

  private deleteurl = 'http://localhost:5054/api/Employee/RemoveEmployee'

  private getidurl = 'http://localhost:5054/api/Employee/GetEmployeeGetById'

  constructor() { }

  http = inject(HttpClient)

  getAllEmployee(){
    return this.http.get<employee[]>(this.apiUrl)
  }


  addemployee(data: any){
    return this.http.post(this.posturl,data)
  }

  // updateData(data: any): Observable<any> {
  //   return this.http.put(`${this.puturl}`, data);
  // }
 

  getemployeebyId(id: number): Observable<any> {
    return this.http.get(`${this.getidurl}/${id}`);
  }
  // getemployeebyId(id : number){
  //   return this.http.get(`${this.getidurl}/${id}`)
  // }

  

  updateEmployee(employee: employee){ {
    return this.http.put(`${this.puturl}/${employee.id}`, employee)
  }
}
  // updateemployee(employedata:employee){
  //   // return this.http.put(this.puturl,employedata)
  //   // return this.http.put('${this.apiurl}/${employee.id}',employedata)
  // }

  deleteemployee(id:number){
    return this.http.delete(`${this.deleteurl}/${id}`)
  }


  onchange : Subject<any> = new Subject<any>();
}



