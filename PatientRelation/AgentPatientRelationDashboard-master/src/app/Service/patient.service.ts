import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { State } from '../Component/Module/State';
import { Country } from '../Component/Module/Country';
import { City } from '../Component/Module/City';
import { Patient } from '../Component/Module/Patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {


  getallurl = 'https://localhost:7062/api/Patient/GetAllPatient'
  

  deleteurl = 'https://localhost:7062/api/Patient/DeletePatient'

  getcountryurl = 'https://localhost:7062/api/Country/GetAllCountry'

  getallstateurl = 'https://localhost:7062/api/State/GetAllState'

  getstatebyidurl = 'https://localhost:7062/api/State'

  getallcityurl ='https://localhost:7062/api/City/GetAllCity'

  getcitybyidurl = 'https://localhost:7062/api/City'

  posturl = 'https://localhost:7062/api/Patient/AddPatient'

  puturl = 'https://localhost:7062/api/Patient/UpdatePatient'


  http = inject(HttpClient)

  constructor() { }

  getallpatient(){
    return this.http.get(this.getallurl)
  }
  // getallpatient(){
  //   const token = localStorage.getItem('token'); // Assuming the token is stored in local storage
  //   const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

  //   return this.http.get(this.getallurl,headers);
  // }

  deletepatient(id:number ){
    return this.http.delete(this.deleteurl+'/'+id)
  }

  getallcountry(){
    return this.http.get<Country[]>(this.getcountryurl)
  }

  getallstate(){
    return this.http.get<State[]>(this.getallstateurl)
  }

  getstatebyid(countryId:number){
    return this.http.get<State[]>(this.getstatebyidurl+'/'+countryId)
    
  }

  getallcity(){
    return  this.http.get<City[]>(this.getallcityurl)
  }

  getcitybyid(stateId:number){
    return this.http.get<City[]>(this.getcitybyidurl+'/'+stateId)
  }


  addpatient(data:any){
    return this.http.post(this.posturl,data)
  }

  updatepatinet(patient:any)
  {
    return this.http.put(this.puturl,patient)
  }

  getpatientbyid(id:number){
    return this.http.get(this.getallurl+'/'+id)
  }


}
