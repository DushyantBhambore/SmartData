import { Pateint } from './../../Modal/pateint';
import { Employee } from './../../Modal/employee';
import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeServiceService } from '../../Service/employee-service.service';
import { PateintService } from '../../Service/pateint.service';

@Component({
  selector: 'app-pateint',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './pateint.component.html',
  styleUrl: './pateint.component.css'
})
export class PateintComponent implements OnInit {

  @ViewChild('myModal') myModal!:ElementRef|undefined

  pateintform : FormGroup = new FormGroup({})

  pateintlist : Pateint[] = [];

  service = inject(PateintService)

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
    this.service.getAllpateint().subscribe(data => {
      this.pateintlist = data
      console.log(this.pateintlist)
    })
  }



  // setvalue Function
  setform()
  {
    this.pateintform = this.fb.group({
      pateintId : [0],
      firstName : ['',Validators.required],
      lastName : ['',Validators.required],
      dateofBirth : ['',Validators.required],
      gender : ['',Validators.required],
      phoneNumber : ['',Validators.required],
      emailAddress : ['',Validators.required],
      addressLine1 : ['',Validators.required],
      addressLine2 : ['',Validators.required],
      salary : ['',Validators.required],
      emergencyContactName : ['',Validators.required],
      emergencyContactNumber : ['',Validators.required],
      maritalStatus : ['',Validators.required],
      city : ['',Validators.required],
      state : ['',Validators.required],
      country : ['',Validators.required],
      postalCode : ['',Validators.required],
      insuranceProvider : ['',Validators.required],
      insurancePolicyNumber : ['',Validators.required],
      primaryPhysician : ['',Validators.required],
      allergies : ['',Validators.required],
      height : ['',Validators.required],
      weight : ['',Validators.required],
      bloodPressure : ['',Validators.required],
      bloodGroup : ['',Validators.required],
      lastVisitDate : ['',Validators.required],
      nextAppointmentDate : ['',Validators.required],
      isActive : ['',Validators.required],
      isDelete : ['',Validators.required],

    })
  }


  onUpdate(data : any){
    this.pateintform.setValue({
      pateintId:data.pateintId,
      firstName : data.firstName,
      lastName :data.lastName,
      dateofBirth : data.dateofBirth,
      gender :  data.gender,
      phoneNumber :data.phoneNumber,
      emailAddress :data.emailAddress,
      addressLine1 :data.addressLine1,
      addressLine2 :data.addressLine2,
      salary :data.salary,
      emergencyContactName :data.emergencyContactName,
      emergencyContactNumber :data.emergencyContactNumber,
      maritalStatus :data.maritalStatus,
      city :data.city,
      state :data.state,
      country :data.country,
      postalCode :data.postalCode,
      insuranceProvider :data.insuranceProvider,
      insurancePolicyNumber :data.insurancePolicyNumber,
      primaryPhysician :data.primaryPhysician,
      allergies :data.allergies,
      height :data.height,
      weight :data.weight,
      bloodPressure :data.bloodPressure,
      lastVisitDate :data.lastVisitDate,
      nextAppointmentDate :data.nextAppointmentDate,
      isActive :data.isActive,
    })
  }



  OpenModal(){
    const empmodal = document.getElementById("myModal")
   
    if(empmodal !=null)
    {
      empmodal.style.display ='block'
    }
    
  }


  
  Onclose()
  {
    if(this.myModal !=null)
    {
      this.myModal.nativeElement.style.display = 'none'
    }
  }
  OnSubmit(){
    console.log(this.pateintform)
    this.formevalue = this.pateintform.value;
    this.service.addpateint(this.formevalue).subscribe((res)=>{
      alert('Emplpoyee Added Successfully ');
      this.getpateint();
      this.pateintform.reset();
      this.Onclose()
    })

  }

  onDelete(id:number){
    this.service.deletepateint(id).subscribe((res)=>{
      alert("Employee is Deleted Succcesfully ")
    this.getpateint();
    console.log("Employee Deleted ")
    });
  }
  

  OnUpdateModal(item: Pateint) {
    this.pateintform.setValue(item);
    this.OpenModal();
  }
  
  OnUpdate() {
    const updatedPatient = this.pateintform.value;
    this.service.updatePateint(updatedPatient).subscribe({
      next: (response) => {
        console.log('Update successful', response);
        alert('Patient Updated Successfully');
        this.getpateint();
        this.Onclose();
        this.pateintform.reset();
      },
      error: (error) => {
        console.error('Update failed', error);
      }
    });

  }
}
