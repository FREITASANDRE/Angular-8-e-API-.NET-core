import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppService } from '../service/app.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SnackbarService } from 'ngx-snackbar';
import { User } from '../model/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private routerActive: ActivatedRoute
    , private appService: AppService
    , private spinnerService: NgxSpinnerService
    , private snackbarService: SnackbarService) { }

  type: string = '';
  response;
  user = new User();
  ngOnInit(): void {
    this.load();
  }

  async load() {
    this.spinnerService.show();
    let id = this.routerActive.snapshot.paramMap.get('id');
    if (id != null) {
      this.type = 'Edição';
      this.response = await this.appService.SendToApi('/User/getById/' + id, null);
      if (this.response.status == 0) {
        this.user = this.response.result;
        this.spinnerService.hide();
      }
    } else {
      this.type = 'Cadastro';
      this.spinnerService.hide();
    }

  }

  async save() {
    this.spinnerService.show();
    if (this.user.id == null) {
      this.response = await this.appService.SendToApi('/User', this.user);
    } else {
      this.response = await this.appService.SendToApi('/User/update/', this.user);
    }
    if (this.response.status == 0) {
      this.user = this.response.result;
      this.showSnackBar(this.response.message, "#33cc33");
      this.spinnerService.hide();
    }else{
      this.showSnackBar(this.response.message, "#e60000");
      this.spinnerService.hide();
    }

  }

  newUser() {
    this.user = new User();
  }

  showSnackBar(pMessage , color){
    this.snackbarService.add({
      msg: "<strong>"+pMessage+"</strong>",
      background: color,
      timeout: 3000,
      action: {
        text: "",
      }
    });
  }
}
