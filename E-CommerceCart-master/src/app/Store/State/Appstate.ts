import { Counter } from "../reducers/counter.reducer";

export interface AppState{
    counter : Counter
}


export interface Products {
    id: number;
    name: string;
    price: number;
    category: string;
    quantity: number;
}