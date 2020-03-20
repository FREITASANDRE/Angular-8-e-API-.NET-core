import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConstants } from '../app-constants';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) { }

  async SendToApi(Path, Data) {
    //implementar chamada para buscar na api e validar os dados do usuário
    console.log(AppConstants.baseServer + Path);
    /*return await this.http.post(AppConstants.baseServer + Path, JSON.stringify(Data)).subscribe(data => {
        data
  }*/
   
  }
}
