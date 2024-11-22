import { removereducer } from './bucket.reducer';
import { createReducer, on } from "@ngrx/store";
import { ElectronicCart } from "../../Modules/ecart";
import { AddProduct, RemoveProduct } from "../actions/ecarts";
import { state } from "@angular/animations";



let initialState : ElectronicCart[] =[];


export const ecartreducer = createReducer(
    initialState,
    on(AddProduct,(state,action)=>{
        const item =state.find(a=>a.id==action.item.id) 
        if(item)
        {
            return state.map(a=>{
                return a.id==action.item.id? {...a,quantity:a.quantity+1}:a
            })
        }
        else{
            return [
                ...state,
                action.item
            ]
        }
    }),
    on(RemoveProduct,(state,action)=>{
        const item =state.find(a=>a.id==action.item.id)
        if(item)
        {
            return state.map(a=>{
                return a.id==action.item.id? {...a,quantity:a.quantity-1}:a
            })
        }
        else{
            return [
                ...state,
                action.item
            ]
        }
    })
)