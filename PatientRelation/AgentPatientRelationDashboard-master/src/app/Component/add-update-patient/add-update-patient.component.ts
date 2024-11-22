import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Patient } from '../Module/Patient';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { PatientService } from '../../Service/patient.service';

@Component({
  selector: 'app-add-update-patient',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './add-update-patient.component.html',
  styleUrl: './add-update-patient.component.css'
})
export class AddUpdatePatientComponent implements OnInit {

  pateintform : FormGroup = new FormGroup({})

  patientvalue : any = []

  patentdata : any =[]

  localdata = JSON.parse(localStorage.getItem('logindata')|| '{}')

  countries : any 
  states :any =[]
  cities : any = []

  service = inject(PatientService)
  route = inject(Router)

  constructor(private fb : FormBuilder){}
  ngOnInit(): void {
    this.setForm();
    // this.loadCountries()
    this.getcountry()
  }


  setForm(){
    this.pateintform = this.fb.group({

      id : [0,Validators.required],
      userId :[0,Validators.required],
      agentId :['',Validators.required],
      dateOfBirth:['',Validators.required],
      firstName : ['',Validators.required],
      lastName:['',Validators.required],
      email :['',Validators.required],
      age : ['',Validators.required],
      gender : ['',Validators.required],
      bloodGroup : ['',Validators.required],
      addressLine1 :['',Validators.required],
      addressLine2 : ['',Validators.required],
      country :[0,Validators.required],
      state : [0,Validators.required],
      city : [0,Validators.required],
      zipCode:['',Validators.required],
      appoinmentDate :['',Validators.required],
      isActive : ['',Validators.required],
      isDelete:['',Validators.required]

    })
  }


  getcountry(){
    this.service.getallcountry().subscribe({
      next:(res)=>{
        console.log(res);
        this.countries=res
      },
      error:(error)=>{
        console.log('I am error in country ',error)
      }
    })
  }
  getstates(){
    this.service.getallstate().subscribe({
      next:(res)=>{
        console.log(res)
      },
      error:(error)=>{
        console.log('I am error in states',error)
      }
    })
  }

  getcity(){
    this.service.getallcity().subscribe({
      next:(res)=>{
        console.log(res)
      },
      error:(error)=>{
        console.log('I am error in states',error)
      }
    })

  }


  loadCountries() {
    this.service.getallcountry().subscribe((data: any) => {
      console.log(data);  // Log the data to verify
      if (Array.isArray(data)) {
        this.countries = data;  // Ensure the data is an array
      } else {
        this.countries = Object.values(data);  // If it's an object, convert to array
      }
    });
  }
  onCountryChange(countryId: number) {
    
    this.service.getstatebyid(countryId).subscribe(data => {
        this.states = data;
        this.cities = []; // Reset cities when country changes
        this.pateintform.patchValue({ state: '', city: '' }); // Reset state and city
    });
}

onStateChange(stateId: number) {
  
  this.service.getcitybyid(stateId).subscribe(data => {
      this.cities = data;
      this.pateintform.patchValue({ city: '' }); // Reset city when state changes
  });
}
  onSubmit(){
    debugger
    // const patientData = { ...this.pateintform.value, userId: this.localdata.aId, agentId: this.localdata.agentId };

    this.patientvalue = {
      ...this.pateintform.value,
      userId: this.localdata?.userId || '',       // Ensure userId is not null
      agentId: this.localdata?.agentId || ''    // Ensure agentId is not null
    };
  
    // this.patientvalue = this.pateintform.value
    this.service.addpatient(this.patientvalue).subscribe({
      next: (res: any) => {
        debugger  
        this.patentdata=res
        alert('Patient added successfully');
        this.route.navigateByUrl('patient');
        this.pateintform.reset();
      },
      error: (error: any) => {
        console.error('Error adding patient:', error);
      }
    });

}

}
