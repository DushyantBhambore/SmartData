import { CommonModule } from '@angular/common';
import { Component, SimpleChange, OnChanges } from '@angular/core';
import { FormBuilder, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-template-forms',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './template-forms.component.html',
  styleUrl: './template-forms.component.css'
})
export class TemplateFormsComponent {

  
  constructor() {
  }
  userForm  = {
    name : '',
    email :'',
    age : null
  };

  route! :"/reactive-forms"

  submitted :boolean = false
  OnSubmit(){
    this.submitted = true
    console.log("Form Data ", this.userForm)
 
  }


 
}
