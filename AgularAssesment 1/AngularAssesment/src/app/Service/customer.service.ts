import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Customer } from '../Modal/customer';
import { Country } from '../Modal/Country';
import { State } from '../Modal/State';
import { City } from '../Modal/City';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customerlisturl ='http://localhost:5114/api/Customer'

  private posturl ='http://localhost:5114/api/Customer'

  private puturl = 'http://localhost:5114/api/Customer'

  private deleteurl ='http://localhost:5114/api/Customer/DeleteCustomer'
  private cityurl = 'http://localhost:5114/api/City'

  private  countryurl = 'http://localhost:5114/api/Country'

  private stateurl = 'http://localhost:5114/api/State'

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

getAllCountries(){
  return this.http.get<Country[]>(this.countryurl)
}

getAllState(){
  return this.http.get<State[]>(this.stateurl)
}
getAllCity(){
  return this.http.get<City[]>(this.cityurl)
}

getStates(countryId: number){
  return this.http.get<State[]>(`${this.stateurl}/${countryId}`)
}
getCities(stateId: number){
  return this.http.get<City[]>(`${this.cityurl}/${stateId}`)

}










}
