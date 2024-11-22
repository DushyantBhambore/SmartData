import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ElectronicCart } from '../../Modules/ecart';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-ecart',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './ecart.component.html',
  styleUrl: './ecart.component.css'
})
export class EcartComponent {


  ecartdata$? : Observable<ElectronicCart[]>

  constructor(private store : Store<{ecart:ElectronicCart[]}>)
  {
    this.ecartdata$ = store.select('ecart')
    
  }

}
