import { Injectable, ɵConsole } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConstants } from '../app-constants';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  
  constructor(private http: HttpClient) { }

 async SendToApi(Path, Data) {
    return this.http.post(AppConstants.baseServer + Path,Data).pipe(
   ).toPromise();
  }
}
