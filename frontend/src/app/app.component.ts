import { Component } from '@angular/core';
import { AppService } from './service/app.service';
import { AppConstants } from './app-constants';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'first-app';

  constructor(private appService: AppService) { }

  user = { mail: '', password: '' };
  message = { error: '' };
  response;

  public async submit() {
      this.message.error = '';
      this.response = '';
      this.response =  await this.appService.SendToApi( '/User/login',this.user);
      if(this.response.message != null)
        this.message.error  = this.response.message;
  }
}
