import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AppState } from '../../Store/State/Appstate';
import { Store } from '@ngrx/store';
import { selectCount } from '../../Store/selectors/counter.selector';
import { AsyncPipe } from '@angular/common';
import { decrement, increment, reset } from '../../Store/actions/counter.action';

@Component({
  selector: 'app-counter',
  standalone: true,
  imports: [AsyncPipe],
  templateUrl: './counter.component.html',
  styleUrl: './counter.component.css'
})
export class CounterComponent {

  count$ : Observable<number>

  constructor(private state : Store<AppState>){
    this.count$ = this.state.select(selectCount)
  }

  increment(){
    this.state.dispatch(increment())
  }

  decrement(){

    this.state.dispatch(decrement())

  }

  reset()
  {
    this.state.dispatch(reset())

  }

}
