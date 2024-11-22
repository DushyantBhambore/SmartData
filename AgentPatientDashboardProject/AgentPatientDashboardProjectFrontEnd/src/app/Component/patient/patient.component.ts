import { Component, inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PatientService } from '../../Service/patient.service';
import { CommonModule, DatePipe, JsonPipe } from '@angular/common';

@Component({
  selector: 'app-patient',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule,DatePipe,JsonPipe],
  templateUrl: './patient.component.html',
  styleUrl: './patient.component.css'
})
export class PatientComponent {

  // loginuser = localStorage.getItem('logindata');
  // loginuser: any;
  pateintdata: any = [];

  isEnable : boolean = false
  pateintform: FormGroup = new FormGroup({});

  patientvalue: any = [];

  patentdata: any = [];

   loginuser = JSON.parse(localStorage.getItem('logindata') || '{}');

  countries: any;
  states: any = [];

  isEditMode : boolean = false
  

  route = inject(Router);

  service = inject(PatientService);
  today: string = new Date().toISOString().slice(0, 16); // yyyy-mm-ddThh:mm format

  dob = new Date().toISOString().split("T")[0]; // Sets today's date in 'YYYY-MM-DD' format


  ngOnInit(): void {
    this.onget();
    this.setForm();
    this.getcountry();
  }
  constructor(private fb: FormBuilder) {}

  onget() {
    this.service.getallpatinet().subscribe({
      next: (res: any) => {``
        console.log('Patient Data ', res);
        // here check the user id null or not
        if (this.loginuser) {
          this.pateintdata = res.filter(
            (p: any) =>
              p.agentId === this.loginuser.agentId &&
              p.userId === this.loginuser.userId
          );
          console.log('Filtered patient data:', this.pateintdata); // Check if data filters correctly
        } else {
          console.error('Unexpected patient data format:', res);
        }
      },
      error: (error) => {
        alert('I am error in Get Patient List ');
      },
    });
  }

  // Delete Patient
  ondelete(id: number) {
    debugger;
    const data = confirm('Are you sure do you want delete this Id ');
    if (data == true) {
      this.service.deletepatient(id).subscribe({
        next: (res) => {
          console.log('deleted', res);
          alert('delete successfully ');
          this.onget();
          window.location.reload();
        },
        error: (error) => {
          alert('I am error in delete');
          console.log('I am error in delete',error);
        },
      });
    }
  }

  // Add and Update Patient

  setForm() {
    this.pateintform = this.fb.group({
      pId: [0, Validators.required],
      userId: [0, Validators.required],
      agentId: ['', Validators.required],
      dateofBirth: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required,],
      age: ['', Validators.required,],
      gender: ['', Validators.required],
      phoneNumber: ['', Validators.required,],
      addressLine1: ['', Validators.required],
      addressLine2: ['', Validators.required],
      country: [0, Validators.required],
      state: [0, Validators.required],
      city: ['', Validators.required],
      zipCode: ['', Validators.required],
      appoinentmentDate: ['', Validators.required],
      isActive: ['', Validators.required],
      isDelete: ['', Validators.required],
    });
  }

  onReset(){
    this.pateintform.reset();
    window.location.reload();
  }

  getcountry() {
    this.service.getallcountry().subscribe({
      next: (res) => {
        console.log(res);
        this.countries = res;
      },
      error: (error) => {
        console.log('I am error in country ', error);
      },
    });
  }
  getstates() {
    this.service.getallstate().subscribe({
      next: (res) => {
        console.log(res);
      },
      error: (error) => {
        console.log('I am error in states', error);
      },
    });
  }

  
  loadCountries() {
    this.service.getallcountry().subscribe((data: any) => {
      console.log(data); // Log the data to verify
      if (Array.isArray(data)) {
        this.countries = data; // Ensure the data is an array
      } else {
        this.countries = Object.values(data); // If it's an object, convert to array
      }
    });
  }
  onCountryChange(countryId: number) {
    this.service.getstatebyid(countryId).subscribe((data) => {
      this.states = data;
      this.pateintform.patchValue({ state: '', }); // Reset state and city
    });
  }

 
  onUpdate(item: any) {
    debugger;
    this.pateintform.patchValue(item); // Populate form with selected employee data
    // this.onCountryChange(item.country);
  }
  onSubmit() {
    debugger;
    // const patientData = { ...this.pateintform.value, userId: this.loginuser.aId, agentId: this.loginuser.agentId };
    this.patientvalue = {
      ...this.pateintform.value,
       userId: this.loginuser.userId ||'',
       agentId: this.loginuser.agentId ||'',// Ensure agentId is not null
    };

    if(this.pateintform.value.pId != 0){
      this.service.updatepatient(this.patientvalue).subscribe({
        next: (res: any) => {
          debugger;
          console.log('Updated data ', res);
          alert('Patient Updated successfully');
          this.onget();
          this.pateintform.reset();
          window.location.reload();
        },
        error: (error: any) => {
          console.error('Error adding patient:', error);
        },
      });
    }else{
      this.service.addpatient(this.patientvalue).subscribe({
        next: (res: any) => {
          debugger;
          console.log('Added data ', res);
          alert('Patient added successfully');
          this.onget();
          this.pateintform.reset();
          window.location.reload();
        },
        error: (error: any) => {
          console.error('Error adding patient:', error);
        },
      });
    }
    }

  }

  

