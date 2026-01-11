import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { CommonConstants } from '../constants/commonConstants';

@Injectable()
export class authInterceptor implements HttpInterceptor {
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    console.log('Interceptor WORKING');
    const token = sessionStorage.getItem('UserToken');
    debugger;
    let tokenizedReq = req.clone({
      setHeaders: {
        'Content-Type': CommonConstants.CONTENT_TYPE,
        apikeyvalue: environment.apikey,
        Accept: '*/*',
      },
    });
    return next.handle(tokenizedReq);
  }
}
