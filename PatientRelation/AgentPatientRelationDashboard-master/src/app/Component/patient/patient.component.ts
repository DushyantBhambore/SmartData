import { Component, inject, OnInit } from '@angular/core';
import { PatientService } from '../../Service/patient.service';
import { CommonModule, DatePipe, JsonPipe, NgFor } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, DatePipe, JsonPipe,FormsModule],
  templateUrl: './patient.component.html',
  styleUrl: './patient.component.css',
})
export class PatientComponent implements OnInit {
  localdata = localStorage.getItem('logindata');
  loginuser: any;
  pateintdata: any = [];

  pateintform: FormGroup = new FormGroup({});

  patientvalue: any = [];

  patentdata: any = [];

  localdata1 = JSON.parse(localStorage.getItem('logindata') || '{}');

  countries: any;
  states: any = [];
  cities: any = [];




  openModal(){
    debugger
    const modal = document.getElementById('mymodel');
    if(modal !=null)
    {
      modal.style.display = 'block'; 
    }

  }

  closeModal(){
    const modal = document.getElementById('mymodel');

    if(modal !=null)
    {
      modal.style.display = 'none'; 
    }

  }























  

  route = inject(Router);

  service = inject(PatientService);
  today: string = new Date().toISOString().slice(0, 16); // yyyy-mm-ddThh:mm format

  ngOnInit(): void {
    this.loginuser = this.localdata ? JSON.parse(this.localdata) : null;
    this.onget();
    this.setForm();
    // this.loadCountries()
    this.getcountry();
  }
  constructor(private fb: FormBuilder) {}

  onget() {
    debugger
    this.service.getallpatient().subscribe({
      next: (res: any) => {
        console.log('Patient Data ', res);
        // here check the user id null or not
        if (this.loginuser?.UserId && Array.isArray(res)) {
          this.pateintdata = res.filter(
            // here the data is come in the array form so we have used the( AgentId, UserId) 
            // instead of agentId, If we use the( agentId userId )this the data is not bind in that 
            // and we give the Json objet error like [object : object ]
            (p: any) =>
              p.agentId === this.loginuser.AgentId &&
              p.userId === this.loginuser.UserId
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
    const data = confirm('Are you sure do you want delete this Id ');
    if (data) {
      this.service.deletepatient(id).subscribe({
        next: (res) => {
          console.log('deleted');
          alert('delete successfully ');
          this.onget();
          window.location.reload();
        },
        error: (error) => {
          console.log('I am error in delete');
        },
      });
    }
  }

  // Add and Update Patient

  setForm() {
    this.pateintform = this.fb.group({
      id: [0, Validators.required],
      userId: [0, Validators.required],
      agentId: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      age: ['', Validators.required],
      gender: ['', Validators.required],
      bloodGroup: ['', Validators.required],
      addressLine1: ['', Validators.required],
      addressLine2: ['', Validators.required],
      country: [0, Validators.required],
      state: [0, Validators.required],
      city: [0, Validators.required],
      zipCode: ['', Validators.required],
      appoinmentDate: ['', Validators.required],
      isActive: ['', Validators.required],
      isDelete: ['', Validators.required],
    });
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

  getcity() {
    this.service.getallcity().subscribe({
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
      this.cities = []; // Reset cities when country changes
      this.pateintform.patchValue({ state: '', city: '' }); // Reset state and city
    });
  }

  onStateChange(stateId: number) {
    this.service.getcitybyid(stateId).subscribe((data) => {
      this.cities = data;
      this.pateintform.patchValue({ city: '' }); // Reset city when state changes
    });
  }

  onUpdate(item: any) {
    debugger;
    this.pateintform.patchValue(item); // Populate form with selected employee data
  }
  onSubmit() {
    debugger;
    // const patientData = { ...this.pateintform.value, userId: this.localdata.aId, agentId: this.localdata.agentId };
    this.patientvalue = {
      ...this.pateintform.value,
       userId: this.localdata1.UserId,
      agentId: this.localdata1.AgentId,// Ensure agentId is not null
    };
    if (this.pateintform.value.id != 0) {
      debugger;
      this.service.updatepatinet(this.patientvalue).subscribe({
        next: (res: any) => {
          debugger;
          this.patentdata = res;
          alert('Update added successfully');
          this.route.navigateByUrl('patient');
          this.onget();
          this.pateintform.reset();
          window.location.reload();

        },
        error: (error: any) => {
          console.error('Error adding patient:', error);
        },
      });
    } else {
      // this.patientvalue = this.pateintform.value
      this.service.addpatient(this.patientvalue).subscribe({
        next: (res: any) => {
          debugger;
          console.log('Updated data ', res);
          alert('Patient added successfully');
          this.onget();
          this.pateintform.reset();
        },
        error: (error: any) => {
          console.error('Error adding patient:', error);
        },
      });
    }
  }
}
