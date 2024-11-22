import { createSelector } from "@ngrx/store";
import { Grocery } from "../../Modules/grocery";



export const groceriesList = createSelector(
  (state: { groceries: Grocery[] }) => state.groceries,
  (groceries: Grocery[]) => groceries
);

// export const groceriesListByType = createSelector(
//     groceriesList,(state)=>{
//         return state.filter((a)=>a.type==='Fruits')
//     }
// )