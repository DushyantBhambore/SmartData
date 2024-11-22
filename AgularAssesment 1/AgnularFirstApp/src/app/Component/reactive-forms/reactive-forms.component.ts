import { CommonModule, JsonPipe } from '@angular/common';
import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormControlDirective,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { EmployeeServiceService } from '../../Services/employee-service.service';

@Component({
  selector: 'app-reactive-forms',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, JsonPipe],
  templateUrl: './reactive-forms.component.html',
  styleUrl: './reactive-forms.component.css',
})
export class ReactiveFormsComponent {
  // contactForm : FormGroup
  submitted: boolean = false;
  formdata: any;

  service = inject(EmployeeServiceService);

  studentForm: FormGroup = new FormGroup({
    studentname: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    age: new FormControl('', Validators.required),
  });

  // constructor(private fb:FormBuilder) {
  //   this.contactForm = this.fb.group({
  //    name :['',Validators.required],
  //    email : ['',Validators.required],
  //    age : ['',Validators.required]
  //   })
  // }

  currentcomponent: string = '';

  constructor() {
    // here i have emmiting the data from the layout component
    this.service.onchange.subscribe((res: any) => {
      this.currentcomponent = res;
    });
  }

  OnSubmit() {
    // this.submitted =true

    this.formdata = this.studentForm.value;
    console.log('formdata', this.formdata);
  }
}
