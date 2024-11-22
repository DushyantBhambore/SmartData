import { ApplicationConfig, provideZoneChangeDetection, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideState, provideStore } from '@ngrx/store';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { provideEffects } from '@ngrx/effects';
import { groceryreducer } from './Store/reducers/grocery.reducer';
import { buckereducer } from './Store/reducers/bucket.reducer';
import { reduce } from 'rxjs';
import { counterreducer } from './Store/reducers/counter.reducer';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { _productreducer, productreducer } from './Store/e-productandbill/product.reducer';
import { cartreducer } from './Store/e-productandbill/cart.reducer';
import { ecartreducer, } from './Store/reducers/ecart.reducer';
import { _electronicproductreducer } from './Store/reducers/electronicproduct.reducer';

export const appConfig: ApplicationConfig = {
  providers: [provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), 
    provideHttpClient(withFetch()),
    // provide reducers
    provideStore({
      groceries:groceryreducer,
      bucketitem : buckereducer,
       products: productreducer,
        cart: cartreducer ,
      eproduct:_electronicproductreducer,
      ecart : ecartreducer,
      electronicproduct: _electronicproductreducer 
    }), 
    provideState({name:'counter',reducer:counterreducer}),
    provideStoreDevtools({ maxAge: 25, logOnly: !isDevMode() }),
     provideEffects()]
};
