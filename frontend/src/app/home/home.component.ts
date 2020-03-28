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
  users: Observable<User[]>;

  constructor(private appService: AppService, private spinnerService: NgxSpinnerService) { }

  ngOnInit() {
    this.reload();
  }

  async changeStatus(user: User) {
    this.spinnerService.show();
    user.status = user.status == "A" ? "I" : "A";
    this.response = await this.appService.SendToApi('/User/update', user);
    if (this.response.status == 0) {
      this.reload();
      this.spinnerService.hide();
    }
  }

  async reload() {
    this.spinnerService.show();
    this.response = await this.appService.SendToApi('/User/getall', null);
    if (this.response.status == 0) {
      this.users = this.response.result;
      this.spinnerService.hide();
    }
  }

}
