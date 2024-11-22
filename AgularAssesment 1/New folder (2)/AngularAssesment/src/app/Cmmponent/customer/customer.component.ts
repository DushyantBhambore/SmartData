import { CustomerService } from './../../Service/customer.service';
import { Component, ElementRef, OnInit, ViewChild, viewChild, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Customer } from '../../Modal/customer';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit {

  // @ViewChild('customermodal') myModal!:ElementRef|undefined

  customeform : FormGroup = new FormGroup({})

  customerlist : Customer[] = [];

  service = inject(CustomerService)

  formevalue : any

  
  constructor(private fb : FormBuilder) {
    
  }
  ngOnInit(): void {
    this.setform();
    this.getpateint();
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
      state : ['',Validators.required],
      purchaseHistory : ['',Validators.required],
      feedback : ['',Validators.required],
      paymentMethod : ['',Validators.required],
      country : ['',Validators.required],
      referralSource : ['',Validators.required],
      companyName : ['',Validators.required],
      city : ['',Validators.required],
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
    this.customeform.setValue(item);
    this.OpenModal();
  }
  
  OnUpdate() {
    const updatedPatient = this.customeform.value;
    this.service.updateCustomer(updatedPatient).subscribe({
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

   



}
