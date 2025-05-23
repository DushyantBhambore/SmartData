import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import {provideAnimations} from '@angular/platform-browser/animations'
import { provideToastr } from 'ngx-toastr';
import { routes } from './app.routes';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withFetch } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideAnimations(),
    provideToastr(), 
    provideAnimationsAsync(),
     provideAnimationsAsync(), 
     provideAnimationsAsync(),
     provideHttpClient(withFetch())
  ]

};
