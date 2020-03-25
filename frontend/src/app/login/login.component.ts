import { Component, OnInit } from '@angular/core';
import { AppService } from '../service/app.service';
import {Router} from '@angular/router';
import { NgxSpinnerService } from "ngx-spinner";  

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  constructor(private appService: AppService, private router: Router,private spinnerService: NgxSpinnerService) { }

  user = { mail: '', password: '' };
  message = { error: '' };
  response;

  ngOnInit():void{
    this.spinnerService.hide();
  }

  public async submit() {
      this.spinnerService.show(); 
      this.message.error = '';
      this.response =  await this.appService.SendToApi( '/User/login',this.user);
      if(this.response.status == 0){
        localStorage.setItem('user',this.response.result.id)
        this.router.navigate(['home']);
      }else{
        this.spinnerService.hide(); 
        this.message.error = this.response.message;
      }
  }
}
