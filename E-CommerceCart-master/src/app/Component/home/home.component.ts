import { Component, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Grocery } from '../../Modules/grocery';
import { Store } from '@ngrx/store';
// import { groceriesList, groceriesListByType } from '../../Store/selectors/grocery.selector';
import { Bucket } from '../../Modules/bucket';
import { BucketAdd, RemoveBucket } from '../../Store/actions/bucket.action';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { groceriesList } from '../../Store/selectors/grocery.selector';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  grocerydata? : Observable<Grocery[]>;

  // store  = inject(Store<{groceries: Grocery[]}>)
  constructor(private store : Store<{groceries: Grocery[]}>){
    // this.grocerydata = store.select(groceriesListByType);
    this.grocerydata = store.select(groceriesList);
  }

  Additem(item:Grocery)
  {
    let loads : Bucket ={
      "id": item.id,
      "name":item.name,
      "quantity":1
    }
    this.store.dispatch(BucketAdd({item:loads}))
  }

  Subitem(item: Grocery) {
    const loads: Bucket = {
      id: item.id,
      name: item.name,
      quantity: 0 // Quantity will be adjusted in the reducer
    };
    this.store.dispatch(RemoveBucket({ item: loads }));
  }
  


}
