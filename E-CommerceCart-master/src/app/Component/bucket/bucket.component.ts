import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Bucket } from '../../Modules/bucket';
import { Store } from '@ngrx/store';
import { AsyncPipe, CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-bucket',
  standalone: true,
  imports: [CommonModule,FormsModule,AsyncPipe],
  templateUrl: './bucket.component.html',
  styleUrl: './bucket.component.css'
})
export class BucketComponent {

  bucketdata? : Observable<Bucket[]>

  constructor(private  store :Store<{bucketitem: Bucket[]}>)
  {
    this.bucketdata = store.select('bucketitem')
  }

}
