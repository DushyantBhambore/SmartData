import { HttpInterceptorFn } from '@angular/common/http';

export const agentInterceptor: HttpInterceptorFn = (req, next) => {

  // First Check you have Add the interceptor in appconfig file (like withInterceptors[nameofinterc])
  const tokendata = localStorage.getItem('token');

  if(tokendata !=null)
  {
    const clonereq = req.clone({
      setHeaders:{
        Authorization: `Bearer ${tokendata}`
      }
    });
    return next(clonereq);  // Pass the cloned request with the header
  }
  return next(req);
};
