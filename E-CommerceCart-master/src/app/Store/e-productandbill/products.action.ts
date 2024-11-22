import { createAction, props } from "@ngrx/store";
import { Products } from "../../Modules/Products";


// load products
export const loadProducts = createAction('[Products] Load Products');

// add  to cart 
// Add to Cart
export const addToCart = createAction('[Cart] Add Item', props<{ product: Products }>());

// Remove from Cart
export const removeFromCart = createAction('[Cart] Remove Item', props<{ productId: number }>());

// Clear Cart
export const clearCart = createAction('[Cart] Clear');

// Update Cart (e.g., quantity)
export const updateCartItem = createAction(
  '[Cart] Update Item',
  props<{ productId: number; quantity: number }>()
);