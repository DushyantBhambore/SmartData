import { createAction, props } from "@ngrx/store";
import { Bucket } from "../../Modules/bucket";



export const BucketAdd = createAction(
    "[Bucket] Add Item",
    props<{item :Bucket|any}>()
)
export const RemoveBucket = createAction(
    "[Bucket] Remove Item",
    props<{item :Bucket|any}>()
)