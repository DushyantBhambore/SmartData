import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Employee } from '../../Modal/employee';
import { EmployeeServiceService } from '../../Service/employee-service.service';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit {
  @ViewChild('myModal') myModal!:ElementRef|undefined


  
  emloyeeform : FormGroup = new FormGroup({})

  employeelist : Employee[] = [];


  service = inject(EmployeeServiceService)

  formevalue : any

  constructor(private fb : FormBuilder) {
    
  }
  ngOnInit(): void {
    this.setform();
    this.getemployee();
  }
  setform()
  {
    this.emloyeeform = this.fb.group({
      employeeID : [0],
      firstName : ['',Validators.required],
      lastName : ['',Validators.required],
      dateofBirth : ['',Validators.required],
      gender : ['',Validators.required],
      phoneNumber : ['',Validators.required],
      department : ['',Validators.required],
      emailAddress : ['',Validators.required],
      address : ['',Validators.required],
      dateofHire : ['',Validators.required],
      salary : ['',Validators.required],
      state : ['',Validators.required],
      emergencyContactName : ['',Validators.required],
      emergencyContactNumber : ['',Validators.required],
      positionTitle : ['',Validators.required],
      maritalStatus : ['',Validators.required],
      country : ['',Validators.required],
      educationLevel : ['',Validators.required],
      city : ['',Validators.required],
      previousEmployer : ['',Validators.required],
      isExpericed : ['',Validators.required],
      skills : ['',Validators.required],


     
    })
  }

  getemployee(){
    this.service.getAllemployee().subscribe(data => {
      this.employeelist = data
      console.log(this.employeelist)
    })
  }


  
  onDelete(id:number){
    this.service.deletemployee(id).subscribe((res)=>{
      alert("Employee is Deleted Succcesfully ")
    this.getemployee();
    console.log("Employee Deleted ")
    });
  }



  OpenModal(){
    const empmodal = document.getElementById("myModal")
   
    if(empmodal !=null)
    {
      empmodal.style.display ='block'
    }
    
  }


  Onclose(){
    if(this.myModal !=null)
    {
      this.myModal.nativeElement.style.display = 'none'
    }
}


OnSubmit(){
  console.log(this.emloyeeform)
  this.formevalue = this.emloyeeform.value;
  this.service.addemployee(this.formevalue).subscribe((res)=>{
    alert('Emplpoyee Added Successfully ');
    this.getemployee();
    this.emloyeeform.reset();
    this.Onclose()
  })

}

OnUpdateModal(item: Employee) {
  this.emloyeeform.setValue(item);
  this.OpenModal();
}

OnUpdate() {
  const updatedPatient = this.emloyeeform.value;
  this.service.updateemployee(updatedPatient).subscribe({
    next: (response) => {
      console.log('Update successful', response);
      alert('Patient Updated Successfully');
      this.getemployee();
      this.Onclose();
    },
    error: (error) => {
      console.error('Update failed', error);
    }
  });

}

}
