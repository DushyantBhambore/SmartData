import { Component, signal, Signal, WritableSignal } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-databinding',
  standalone: true,
  imports: [FormsModule], // we used the form Module for two way data binding 
  templateUrl: './databinding.component.html',
  styleUrl: './databinding.component.css'
})
export class DatabindingComponent {

  // initialize the variables in typescript 

  coursename : string =".net core with angular "

  City !:string

  inputype = "checkbox"

  inputtext = "text"

  rollnumber : number = 234
  
  isactive : boolean = true

  bgcolor  = "bg-success"

  CurrentDate : Date = new Date()

  firstname = signal("Dushyant Bhambore ")

  inputval : WritableSignal<string> = signal<string>('')

  constructor(){

  }

  // Two way data binding is happend only on the input variables ex input,dropdown ,checkbox etc 

  // One Way data Binding 
  // creating one event 

  showalert(message :string){
    alert(message)
  }
  

  // Variable Binding 
  changeActivestatus()
  {
    this.isactive = true
    this.coursename = " Angular 18"
    this.CurrentDate = new Date(2023,12,3)
    this.firstname.set("Virat Kohali")
  }

}