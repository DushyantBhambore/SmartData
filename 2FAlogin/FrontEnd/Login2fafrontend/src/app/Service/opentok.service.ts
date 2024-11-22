import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OpentokService {

  http = inject(HttpClient)

  constructor() { }
}
