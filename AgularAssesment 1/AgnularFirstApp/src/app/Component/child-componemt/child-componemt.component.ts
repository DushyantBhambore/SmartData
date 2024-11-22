import { ChildModel } from './../../Model/child.model';
import { Component, DoCheck, Input, input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-child-componemt',
  standalone: true,
  imports: [],
  templateUrl: './child-componemt.component.html',
  styleUrl: './child-componemt.component.css'
})
export class ChildComponemtComponent implements OnInit ,OnChanges ,DoCheck{
  
  // Input property 
  
  @Input()
  data!: number;

  //Acces the ChildModel as Input 
  @Input() child! :  ChildModel
  /**
 *
 */
constructor() {
  console.log("child constructor is invoked ")
}
  ngDoCheck(): void {
    console.log(this.child)
  }
  ngOnInit(): void {
   console.log("This is child ng onit invoked ")
  }
 
  /**
   *
   */

  // on changes is shows  in console  the object value it has three paremeter 
  // current value 
  // firstcanges 
  // previous values

  ngOnChanges(changes :SimpleChanges): void {
    console.log(changes)
  }
 


}
