import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ElectronicsProduct } from "../../Modules/electonicsproduct";
import { state } from "@angular/animations";


// debugger
// export const productlist = createFeatureSelector<ElectronicsProduct[]>('electronicproduct');


// export const productlistbycategory = createSelector(
//     productlist,(state)=>{
//         return state.filter((a)=>a.category==='Electronics')
//     }
// )

export const productlist = createFeatureSelector<ElectronicsProduct[]>('electronicproduct'); 
export const productlistbycategory = createSelector( productlist, (state: ElectronicsProduct[] | undefined) => 
    { return (state || []).filter(a => a.category === 'Electronics');
        
     } );