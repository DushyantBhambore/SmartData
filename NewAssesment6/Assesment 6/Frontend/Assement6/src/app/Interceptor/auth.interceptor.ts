import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  debugger
  // First Check you have Add the interceptor in appconfig file (like withInterceptors[nameofinterc])
  const tokendata = localStorage.getItem('token')
  if(tokendata !=null)
  {
    debugger
    const clonereq = req.clone({
      setHeaders:{
        Authorization: `Bearer ${tokendata}`
      }
    });
    return next(clonereq);  // Pass the cloned request with the header
  }
  return next(req);
};
