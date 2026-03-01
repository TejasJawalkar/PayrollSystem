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
    const token = sessionStorage.getItem('UserToken');

    let headers: any = {
      'Content-Type': CommonConstants.CONTENT_TYPE,
      Accept: '*/*',
      apikeyvalue: environment.apikey,
    };

    if (token) {
      headers['Authorization'] = `Bearer ${token}`;
    }

    const tokenizedReq = req.clone({
      setHeaders: headers,
    });
    return next.handle(tokenizedReq);
  }
}
