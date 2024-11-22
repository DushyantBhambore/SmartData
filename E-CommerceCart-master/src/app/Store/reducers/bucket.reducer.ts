import { createReducer, on } from "@ngrx/store";
import { Bucket } from "../../Modules/bucket";
import { BucketAdd, RemoveBucket } from "../actions/bucket.action";



let  initialState : Bucket[] =[];

export const buckereducer = createReducer(
    initialState,
    on(BucketAdd,(state,action)=>{
        const payload = state.find(a=>a.id==action.item.id)
        if(payload)
        {
            return state.map(z=>{
                return z.id==action.item.id? {...z,quantity:z.quantity+1}:z
            })
        }
        else{
            return[
                ...state,
                action.item
            ]
        }
    })
)


export const removereducer = createReducer(
    initialState,
    on(RemoveBucket, (state, action) => {
        const existingItem = state.find(item => item.id === action.item.id);
        if (existingItem) {
          return state
            .map(item =>
              item.id === action.item.id
                ? { ...item, quantity: item.quantity - 1 }
                : item
            )
            .filter(item => item.quantity > 0); // Remove items with quantity 0
        }
        return state; // If item doesn't exist, return state unchanged
      })
  );
  