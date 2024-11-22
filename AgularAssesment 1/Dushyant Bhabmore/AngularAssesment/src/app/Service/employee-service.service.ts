import { HttpClient } from '@angular/common/http';
import { inject, Inject, Injectable } from '@angular/core';
import { Pateint } from '../Modal/pateint';
import { Customer } from '../Modal/customer';
import { Employee } from '../Modal/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

 private posturl = 'http://localhost:5114/api/Employees'

 private geturl = 'http://localhost:5114/api/Employees'

 private puturl = 'http://localhost:5114/api/Employees'

 private deleteurl = 'http://localhost:5114/api/Employees/DeleteEmployee'


  http = inject(HttpClient)

  constructor() { }

  deletemployee(id:number){
    return this.http.delete(`${this.deleteurl}/${id}`)
  }
  
  getAllemployee(){
    return this.http.get<Employee[]>(this.geturl)
  }

  addemployee(data: any){
    return this.http.post(this.posturl,data)
  }


  updateemployee(employee: Employee){ {
    return this.http.put(this.puturl, employee)
  }

}
}
