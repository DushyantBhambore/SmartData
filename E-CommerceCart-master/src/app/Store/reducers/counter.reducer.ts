import { createReducer, on } from "@ngrx/store";
import { decrement, increment, reset } from "../actions/counter.action";
import { count } from "rxjs";


export interface Counter{
    count :number 
}

export const initialCounterState : Counter = {
    count:0
}


export const counterreducer = createReducer(
    initialCounterState,
    on(increment,(state)=>({
        ...state, count:state.count+1
    })),
    on(decrement,(state)=>({
        ...state, count:state.count-1
    })),
    on(reset,(state)=>({
        ...state,count:0
    }))
    


)