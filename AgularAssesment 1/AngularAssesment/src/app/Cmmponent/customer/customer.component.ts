import { State } from './../../Modal/State';
import { CustomerService } from './../../Service/customer.service';
import { Component, ElementRef, OnInit, ViewChild, viewChild, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Customer } from '../../Modal/customer';
import { Country } from '../../Modal/Country';
import { City } from '../../Modal/City';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit {

  // @ViewChild('customermodal') myModal!:ElementRef|undefined

  customeform : FormGroup = new FormGroup({})

  customerlist : Customer[] = [];

  service = inject(CustomerService)


  formevalue : any
  countries: any [] =[];
  states: any [] =[];
  cities: any []= [];
  
  constructor(private fb : FormBuilder) {
    
  }
  ngOnInit(): void {
    this.getCountries();
    // this.getState();
    this.getState();
    // this.getCity();
    this.setform();
    this.getpateint();
  }
  
  getCountries() {
    this.service.getAllCountries().subscribe(data => {
        this.countries = data;
        console.log(this.countries)
    });
}
getState() {
  this.service.getAllState().subscribe(data => {
      this.states = data;
  console.log(this.states)
  });
}
getCity() {
  this.service.getAllCity().subscribe(data => {
      this.cities = data;
      console.log(this.cities)
  });
}

onCountryChange(countryId: number) {
  this.service.getStates(countryId).subscribe(data => {
      this.states = data;
      this.cities = []; // Reset cities when country changes
      const stateId = this.customeform.get('stateId')?.value;
      if (stateId) {
        this.onStateChange(stateId);
      } else {
        this.customeform.patchValue({ state: '', city: '' }); // Reset state and city

      }
  });
}

onStateChange(stateId: number) {
  this.service.getCities(stateId).subscribe(data => {
      this.cities = data;
      const cityId = this.customeform.get('cityId')?.value;
      if (!cityId) {
        this.customeform.patchValue({ city: '' }); // Reset city when state changes
      }
  });
}

  // GetAll Pateint

  getpateint()
  {
    this.service.getAllCustomer().subscribe(data => {
      this.customerlist = data
      console.log(this.customerlist)
    })
  }
  

  setform()
  {
    this.customeform = this.fb.group({
      customerID : [0],
      firstName : ['',Validators.required],
      lastName : ['',Validators.required],
      dateofBirth : ['',Validators.required],
      gender : ['',Validators.required],
      phoneNumber : ['',Validators.required],
      customerAddressLine1 : ['',Validators.required],
      customerAddressLine2 : ['',Validators.required],
      customerEmail : ['',Validators.required],
      occupation : ['',Validators.required],
      income : ['',Validators.required],
      state : [0,Validators.required],
      purchaseHistory : ['',Validators.required],
      feedback : ['',Validators.required],
      paymentMethod : ['',Validators.required],
      country  : [0,Validators.required],
      referralSource : ['',Validators.required],
      companyName : ['',Validators.required],
      city: [0, Validators.required],
      creditScore : ['',Validators.required],
      socialMediaHandle : ['',Validators.required],
      lastLoginDate : ['',Validators.required],
      isActive : ['',Validators.required],
      isDelete : ['',Validators.required]
    })
  }

  // Open Form Dialog
  OpenModal(){
    const empmodal = document.getElementById("customermodal")
   
    if(empmodal !=null)
    {
      empmodal.style.display ='block'
    }
    
  }

  // Close Form Dialog
  Onclose(){
    const empmodal = document.getElementById("customermodal")

    if(empmodal !=null)
    {
      empmodal.style.display = 'none'
    }
  }

    
// Delete Customer
      onDelete(id:number){
        this.service.deletCustomer(id).subscribe((res)=>{
          alert("Employee is Deleted Succcesfully ")
        this.getpateint();
        console.log("Employee Deleted ")
        });
      }
    
// Add Customer
  OnSubmit(){
    console.log(this.customeform)
    this.formevalue = this.customeform.value;
    this.service.addCustomer(this.formevalue).subscribe((res)=>{
      alert('Emplpoyee Added Successfully ');
      this.getpateint();
      this.customeform.reset();
      this.Onclose()
    })

  }

  // Update Customer
  OnUpdateModal(item: Customer) {
    this.customeform.patchValue(item);
    this.onCountryChange(item.country); // Load states for selected country
    this.onStateChange(item.state); // 
    console.log(this.customeform,"a")
    this.OpenModal();
  }
  
  OnUpdate() {
    this.formevalue = this.customeform.value;
    this.service.updateCustomer(this.formevalue).subscribe({
      next: (response) => {
        console.log('Update successful', response);
        alert('Patient Updated Successfully');
        this.getpateint();
        this.Onclose();
    this.customeform.reset();

      },
      error: (error) => {
        console.error('Update failed', error);
      }
    });

  }


    getCountryName(countryId: number): string {
    const country = this.countries.find(c => c.Country === countryId);
    return country ? country.name : 'Not Found';
  }

  getStateName(stateId: number): string {
    const state = this.states.find(s => s.sstate === stateId);
    return state ? state.name : 'Not Found';
  }


}
