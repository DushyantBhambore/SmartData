import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const loginGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const logindata = localStorage.getItem('logindata');
  if (logindata !=null) {
    return true;
  } else {
    router.navigateByUrl('login');
    return false;
  }
};
