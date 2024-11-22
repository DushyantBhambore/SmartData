import { HttpClient } from '@angular/common/http';
import { inject, Inject, Injectable } from '@angular/core';
import { Pateint } from '../Modal/pateint';
import { Customer } from '../Modal/customer';
import { Employee } from '../Modal/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

 private apiurl = 'http://localhost:5114/api/Employees'

 private deleteurl = 'http://localhost:5114/api/Employees/DeleteEmployee'


  http = inject(HttpClient)

  constructor() { }

  deletemployee(id:number){
    return this.http.delete(`${this.deleteurl}/${id}`)
  }
  
  getAllemployee(){
    return this.http.get<Employee[]>(this.apiurl)
  }

  addemployee(data: any){
    return this.http.post(this.apiurl,data)
  }


  updateemployee(employee: Employee){ {
    return this.http.put(this.apiurl, employee)
  }

}
}
