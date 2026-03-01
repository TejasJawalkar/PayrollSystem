import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  BaseUrl: string = '';
  envprodtype: boolean = environment.production;
  constructor(private http: HttpClient) {
    if (!environment.production) {
      this.BaseUrl = environment.local_base_url;
    } else {
      this.BaseUrl = environment.prod_base_url;
    }
  }

  getOrgnisation = (): Observable<any> => {
    return this.http.post(`${this.BaseUrl}Orgnisation`, null);
  };
}
