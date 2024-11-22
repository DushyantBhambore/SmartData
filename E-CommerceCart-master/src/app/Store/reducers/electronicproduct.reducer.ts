import { Action, createReducer } from "@ngrx/store";
import { ElectronicsProduct } from "../../Modules/electonicsproduct";


let initialState: ElectronicsProduct[] = [

    { "id": 1, "name": "Laptop", "price": 55000, "category": "Electronics" },
    { "id": 2, "name": "Mobile", "price": 30000, "category": "Electronics" },
    { "id": 3, "name": "Tablet", "price": 20000, "category": "Electronics" },
    { "id": 4, "name": "Camera", "price": 40000, "category": "Electronics" },
]
export const _electronicproductreducer = createReducer(initialState)

// export function electronicproductreducer(state: ElectronicsProduct[] | undefined, action: Action)
//  { return _electronicproductreducer(state, action); }