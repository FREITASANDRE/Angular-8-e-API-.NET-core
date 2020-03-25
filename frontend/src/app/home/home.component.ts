import { Component, OnInit } from '@angular/core';
import { AppService } from '../service/app.service';
import { Observable } from 'rxjs';
import { User } from '../model/user';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  response;
  users : Observable<User[]>;

  constructor(private appService: AppService, private spinnerService: NgxSpinnerService) { }

  async ngOnInit() {
    this.spinnerService.show(); 
    this.response =  await this.appService.SendToApi( '/User/getall',null);
      if(this.response.status == 0){
        this.users = this.response.result;
        this.spinnerService.hide(); 
      }
  }

}
