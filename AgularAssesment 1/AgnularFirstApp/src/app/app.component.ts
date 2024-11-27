import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ChildComponemtComponent } from './Component/child-componemt/child-componemt.component';
import { ChildModel } from './Model/child.model';
import { DatabindingComponent } from './Component/databinding/databinding.component';
import { ReactiveFormsComponent } from './Component/reactive-forms/reactive-forms.component';
import { TemplateFormsComponent } from './Component/template-forms/template-forms.component';
import { EmployeeComponent } from './Component/employee/employee.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,EmployeeComponent,ChildComponemtComponent,DatabindingComponent,ReactiveFormsComponent,TemplateFormsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  // it it  pubic property 
  public count :number =0;

  // initilize the childModel property to variable 
  // Passing the input paraeter to the ChildModel 
  public obj : ChildModel= {id :12,name :'arun'}

  // create a function on button press the button the count will increase 
  counter(){
    this.count++;
    // the will asssining the value
    // here we are  not get  updated value of 
    // it is a reffering the value 
    // to solve this we have use the docheck 
    this.obj.id = this.count++;
  }

  /**
   *
   */

  // FIrst invoked parent constructor 
  // then inveokde child constructor 
  constructor() {
    console.log("The Parent Constructor is invoked ")
  }

  // invoked parent ngoninit  then child ngoninit
  ngOnInit(): void {
    console.log("This is parent ng oninit invoked")
  }
  title = 'AgnularFirstApp';


}
