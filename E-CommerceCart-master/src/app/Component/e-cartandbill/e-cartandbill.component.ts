import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { CartItem } from '../../Modules/Carts';
import { Store } from '@ngrx/store';
import { removeFromCart, updateCartItem } from '../../Store/e-productandbill/products.action';
import { selectCartItems, selectCartTotal } from '../../Store/e-productandbill/product.selector';

@Component({
  selector: 'app-e-cartandbill',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './e-cartandbill.component.html',
  styleUrl: './e-cartandbill.component.css'
})
export class ECartandbillComponent {
  cartItems$: Observable<CartItem[]>;
  cartTotal$: Observable<number>;

  constructor(private store: Store) {
    this.cartItems$ = this.store.select(selectCartItems);
    this.cartTotal$ = this.store.select(selectCartTotal);
  }

  removeItem(productId: number) {
    this.store.dispatch(removeFromCart({ productId }));
  }

  updateQuantity(productId: number, quantity: number) {
    this.store.dispatch(updateCartItem({ productId, quantity }));
  }

}
