import { Component } from '@angular/core';
import { AppService } from './service/app.service';
import { AppConstants } from './app-constants';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'first-app';

  constructor(private appService: AppService) { }

  user = { login: '', password: '' };
  message = { error: '' };

  public submit() {
    if (this.user.login == '' || this.user.password == '')
      this.message.error = "Usuario e senha são obrigatórios";
    else {
      this.message.error = '';
      var teste = this.appService.SendToApi( '/Auth/Login',this.user);
    }
  }
}
