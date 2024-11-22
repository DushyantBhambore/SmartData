import { createAction, props } from "@ngrx/store"
import { ElectronicCart } from "../../Modules/ecart"




export const AddProduct = createAction(
    "[ElectronicProduct] Add Item",
    props<{item :ElectronicCart|any}>()
)

export const RemoveProduct = createAction(
    "[ElectronicProduct] Remove Item",
    props<{item :ElectronicCart|any}>()
)