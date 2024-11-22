import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Products } from "../../Modules/Products";
import { CartItem } from "../../Modules/Carts";

export const selectProductState = createFeatureSelector<Products[]>('products');
export const selectCartState = createFeatureSelector<CartItem[]>('cart');

export const selectProductsByCategory = (category: string) =>
  createSelector(selectProductState, (products) =>
    products.filter((product) => product.category === category)
  );

export const selectCartTotal = createSelector(selectCartState, (cart) =>
  cart.reduce((total, item) => total + item.price * item.quantity, 0)
);

export const selectCartItems = createSelector(selectCartState, (cart) => cart);
