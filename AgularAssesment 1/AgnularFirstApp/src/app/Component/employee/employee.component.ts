import { employee } from './../../Model/employee';
import { Component, ElementRef, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeServiceService } from '../../Services/employee-service.service';

@Component({
  selector: 'app-employee',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent implements OnInit  {


  //close the modal using viewchild 
  @ViewChild("myModal") model : ElementRef | undefined;
  
  employeeform :FormGroup 
  
  employeelist : employee[] =[];

  data! : employee 

  formvalue : any

  constructor(private readonly fb : FormBuilder ) {
    this.employeeform = this.fb.group({
      id: null,
      firstName :['',Validators.required],
      lastName : ['',Validators.required],
      salary : ['',Validators.required]
    })
    
  }




  employeeservice =inject(EmployeeServiceService)
  ngOnInit(): void {
    this.getEmployee();
    
  }

  getEmployee(){
    this.employeeservice.getAllEmployee().subscribe((res)=>{
      this.employeelist =res
      console.log(this.employeelist,"a")
    })
  }
  
  OpenModal()
  {
    const empmodal = document.getElementById("myModal")
   
    if(empmodal !=null)
    {
      empmodal.style.display ='block'
    }
    
  }
  OpenModal1(id: number) {
    const empmodal = document.getElementById("myModal");
    if (empmodal != null) {
      // Fetch data before displaying modal
      this.employeeservice.getemployeebyId(id).subscribe((employee) => {
        this.employeeform.setValue(employee);
        empmodal.style.display = 'block'; // Show modal after data is set
      });
    }
  }
  

  Onclose(){
    this.employeeform.value
    if(this.model !=null)
    {
      this.model.nativeElement.style.display = 'none'
    }
  }

  // Update 
    OnUpdateModal(employeedata :employee){
    this.OpenModal();
    this.employeeform.patchValue(employeedata)
      }


  /// Add Employee


  onSubmit() {
    console.log(this.employeeform.value);
    if (this.employeeform.invalid) {
      alert('Please Fill All Fields');
      return;
    }
    if (this.employeeform.value.id == 0) {
      this.formvalue = this.employeeform.value;
      this.employeeservice.addemployee(this.formvalue).subscribe((res) => {

        alert('Employee Added Successfully');
        this.getEmployee();
        this.employeeform.reset();
        this.Onclose();

      });
    } else {
      this.formvalue = this.employeeform.value;
      this.employeeservice.updateEmployee(this.formvalue).subscribe((res) => {

        alert('Employee Updated Successfully');
        this.getEmployee();
        this.employeeform.reset();
        this.Onclose();

      });
    }

  }

  // OnSubmit(){

  //   console.log(this.employeeform)
  //   this.formvalue = this.employeeform.value;
  //   this.employeeservice.addemployee(this.formvalue).subscribe((res)=>{
  //     alert('Emplpoyee Added Successfully ');
  //     this.getEmployee();
  //     this.employeeform.reset();
  //     this.Onclose()
  //   })

  // }

  // OnUpdateModal(employeedata :employee){
  //   this.OpenModal();
  //   this.employeeform.patchValue(employeedata)
  //   this.OnUpdate(employeedata)
  //     }

// OnUpdate(employeedata:employee){
  
//   this.employeeservice.updateData(employeedata).subscribe({
//     next: (response) => {
//       console.log('Update successful', response);
//     },
//     error: (error) => {
//       console.error('Update failed', error);
//     }
//   });
//   this.getEmployee();

// }
   


  ongetid(id:number){
    this.employeeservice.getemployeebyId(id).subscribe((employee) => {
      this.employeeform.setValue(employee)
    });
  }

  // OnUpdate() {
  //   this.OpenModal();
  
  //   // Ensure the form has the correct id value before updating

  //   const updatedEmployee = this.employeeform.value;
    
  //   this.employeeservice.updateData(updatedEmployee).subscribe({
  //     next: (response) => {
  //       console.log('Update successful', response);
  //     },
  //     error: (error) => {
  //       console.error('Update failed', error);
  //     }
  //   });
  //   this.getEmployee();
  // }
  




  // OnUpdate() {
  //   this.OpenModal();
  //   this.employeeservice.updateData(this.employeeform).subscribe(
  //     { next : (response) => {
  //       console.log('Update successful', response);
  //     },
  //     error: (error) => {
  //       console.error('Update failed', error);
  //     }}
  //   );
  //   this.getEmployee()
  // }



  // onGetId(id: number) {
  //   this.employeeservice.getemployeebyId(id).subscribe((employee) => {
  //     this.employeeform.setValue(employee);
  //   });
  // }
  
  // OnUpdate() {
  //   // const id = this.employeeform.get('id')?.value;
  //   this.OpenModal(); // Fetch data and open modal
  
  //   // Now proceed to update the data
  //   const updatedEmployee = this.employeeform.value;
  //   this.employeeservice.updateData(updatedEmployee).subscribe({
  //     next: (response) => {
  //       console.log('Update successful', response);
  //       this.Onclose(); 
  //     },
  //     error: (error) => {
  //       console.error('Update failed', error);
  //     }
  //   });
  //   this.getEmployee();
  // }
  

  onDelete(id:number){
    this.employeeservice.deleteemployee(id).subscribe((res)=>{
      alert("Employee is Deleted Succcesfully ")
    this.getEmployee();
    console.log("Employee Deleted ")
    });
  }

 
}
