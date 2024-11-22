import { Pateint } from './../Modal/pateint';
import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PateintService {

   private apiurl = 'http://localhost:5114/api/Pateint'

   private  deleteurl = 'http://localhost:5114/api/Pateint/DeletePateint'

   
  constructor() { }
  http = inject(HttpClient)


  getAllpateint(){
    return this.http.get<Pateint[]>(this.apiurl)
  }
  deletepateint(id:number){
    return this.http.delete(`${this.deleteurl}/${id}`)
  }

  addpateint(data: any){
    return this.http.post(this.apiurl,data)
  }
  updatePateint(pateint: Pateint){ {
    return this.http.put(this.apiurl, pateint)
  }
}
}




