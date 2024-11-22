import { createReducer, on } from "@ngrx/store";
import { Products } from "../../Modules/Products";
import { loadProducts } from "./products.action";
import { state } from "@angular/animations";


export const initialState:Products[] = [
    
]
let values:any=
    { id: 1, name: 'T-shirt', price: 500, category: 'Mens Wear', quantity: 1 }
export const _productreducer = createReducer(initialState);

export const productreducer = createReducer(
    initialState,
    on(loadProducts,(state,Action)=>{
        return [...state,values]
    }
    
)

);



