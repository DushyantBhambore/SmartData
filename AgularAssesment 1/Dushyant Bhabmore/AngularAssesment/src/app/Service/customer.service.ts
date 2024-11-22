import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Customer } from '../Modal/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customerlisturl ='http://localhost:5114/api/Customer'

  private posturl ='http://localhost:5114/api/Customer'

  private puturl = 'http://localhost:5114/api/Customer'

  private deleteurl ='http://localhost:5114/api/Customer/DeleteCustomer'


  http = inject(HttpClient)

  constructor() { }

  deletCustomer(id:number){
    return this.http.delete(`${this.deleteurl}/${id}`)
  }
  
  getAllCustomer(){
    return this.http.get<Customer[]>(this.customerlisturl)
  }

  addCustomer(data: any){
    return this.http.post(this.posturl,data)
  }



  updateCustomer(customer: Customer){ {
    return this.http.put(this.puturl, customer)
  }
}












}
