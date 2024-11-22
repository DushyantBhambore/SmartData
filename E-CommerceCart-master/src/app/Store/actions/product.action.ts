import { createAction, props } from "@ngrx/store";
import { IProduct } from "../../Modules/product.interface.";




export const loadProduct = createAction(
    '[Product Component] loadProduct',
)

export const loadProductSuccess = createAction(
    '[Product Component] loadProductSuccess',
    props<{products : IProduct[]}>()
)

export const loadProductFailure = createAction(
    '[Product Component] loadProductFailure',
    props<{errorMessage : string}>()
)

export const increamentProduct = createAction(
    '[Cart Component] IncrementProduct',
    props<{prodcutId : number}>()
);

export const decrementProduct = createAction(
    '[Cart Component] DecrementProduct',
    props<{prodcutId : number}>()
);

export const removeItem = createAction(
    '[Cart Component] RemoveItem',
    props<{prodcutId : number}>()
)