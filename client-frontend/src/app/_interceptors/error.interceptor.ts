import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
// import { __values } from 'tslib';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if(error){
          switch (error.status){
            case 400:
              var errors = error.error.errors;
              const modalStateErrors = [];
              if(errors){
                for (const key in errors) {
                  if(errors[key])
                  modalStateErrors.push(errors[key]);
                  }
                  throw modalStateErrors.flat();
                } else {
                  // this.toastr.error(error.statusText, error.status);
                  this.toastr.error(error.statusText === 'OK' ? 'Bad request' : error.statusText, error.status);
                }
            
            break;
            
            case 401:
              // this.toastr.error(error, error.status);
              this.toastr.error(error.statusText === 'OK' ? 'Unauthorised' : error.statusText, error.status);
              break;
              
            case 404:
              this.router.navigateByUrl('/not-found');
              break;

            case 500:
              const navigationExtras: NavigationExtras = {state: {error: error.error}};
              this.router.navigateByUrl('/server-error', navigationExtras);
              break;

            deafault:
              this.toastr.error('Something unexpected happened');
              console.log(error);
            break;

          }
        }

        return throwError(error);
      })
    )
  }
}
