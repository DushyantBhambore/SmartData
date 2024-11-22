import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Country } from '../Module/Country';
import { State } from '../Module/State';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  addpatienturl = 'https://localhost:7010/api/Patient/AddPatient';
  getallpatienturl = 'https://localhost:7010/api/Patient/GetAllPatient';
  getbyidurl = 'https://localhost:7010/api/Patient';
  updateurl = 'https://localhost:7010/api/Patient/UpdatePatient';

  deletepatinturl='https://localhost:7010/api/Patient/DeletePatient'

  getallcountryurl = 'https://localhost:7010/api/Country/GetAllCountry';

  getallstateurl = 'https://localhost:7010/api/State/GetAllState';
  getstatebyidurl = 'https://localhost:7010/api/State';


  http = inject(HttpClient);
  constructor() {}

  addpatient(data:any){
    return this.http.post(this.addpatienturl,data)
  }

  getallpatinet()
  {
    return this.http.get(this.getallpatienturl)
  }

  getpatientbyid(id:number){
    return this.http.get(this.getbyidurl+id)
  }

  updatepatient(data:any){
    return this.http.put(this.updateurl,data)
  }
  deletepatient(id:number){
    return this.http.delete(this.deletepatinturl+"/"+id)
  }
  getallcountry(){
    return this.http.get<Country>(this.getallcountryurl)
  }
  getallstate(){
    return this.http.get<State>(this.getallstateurl)
  }

  getstatebyid(id:number){
     return this.http.get<State>(this.getstatebyidurl+"/"+id)
  }


}
