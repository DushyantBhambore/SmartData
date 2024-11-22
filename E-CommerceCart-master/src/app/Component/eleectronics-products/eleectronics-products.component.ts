import { AddProduct, RemoveProduct } from './../../Store/actions/ecarts';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { ElectronicsProduct } from '../../Modules/electonicsproduct';
import { select, Store } from '@ngrx/store';
import { productlistbycategory } from '../../Store/selectors/elctronisproduct.selector';
import { ElectronicCart } from '../../Modules/ecart';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-eleectronics-products',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './eleectronics-products.component.html',
  styleUrl: './eleectronics-products.component.css'
})
export class EleectronicsProductsComponent 
{

  // electronicproduts$? : Observable<ElectronicsProduct[]>

  // constructor(private store : Store<{eproduct : ElectronicsProduct[]}>)
  // {
  //   debugger  
  //   this.electronicproduts$ = store.select(productlistbycategory)
  // }

  electronicproducts$: Observable<ElectronicsProduct[]>; 
  constructor(private store: Store<{ electronicproduct: ElectronicsProduct[] }>)
   { this.electronicproducts$ = this.store.select(productlistbycategory); }

  AddProduct(item : ElectronicsProduct)
  {
    let load : ElectronicCart={
      id: item.id,
      name: item.name,
      price: item.price,
      quantity: 1
    }
    this.store.dispatch(AddProduct({item:load}))
  }

  SubProduct(item : ElectronicsProduct){
    let load : ElectronicCart ={
      id: item.id,
      name: item.name,
      price: item.price,
      quantity: 0
    }
    this.store.dispatch(RemoveProduct({item:load}))
  }

}
