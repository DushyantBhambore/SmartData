import { state } from "@angular/animations";
import { CartItem } from "../../Modules/Carts";
import { addToCart, clearCart, removeFromCart, updateCartItem } from "./products.action";
import { createReducer, on } from "@ngrx/store";

let initialState: CartItem[] =[];

export const cartreducer = createReducer(
    initialState,
    on(addToCart,(state: any,action)=>{
      const existingItem = state.find(((a: { id: number; })=>a.id==action.product.id));
      if(existingItem)
        {
            return state.map((a: { id: number; quantity: number; })=>a.id==action.product.id?{...a,quantity:a.quantity+1}:a)

        } 
        else{
            return[...state,action.product]
        }  

    }),
    on(removeFromCart, (state, { productId }) => state.filter((item) => item.id !== productId)),
    on(updateCartItem, (state, { productId, quantity }) =>
      state.map((item) =>
        item.id === productId ? { ...item, quantity } : item
      )
    ),
    on(clearCart, () => [])

)