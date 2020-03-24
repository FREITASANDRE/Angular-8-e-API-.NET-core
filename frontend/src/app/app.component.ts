import { Component, OnInit } from '@angular/core';
import { AppService } from './service/app.service';
import {Router} from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: []
})
export class AppComponent implements OnInit {
  title = 'first-app';

  constructor(private appService: AppService, private router: Router) { }

    ngOnInit(): void{

      if(localStorage.getItem("user") == null){
        this.router.navigate(['login']);
      }else{
        this.router.navigate(['home']);
      }
    }

    public logout (){
      localStorage.clear();
      this.router.navigate(['login']);
    }

    public hideMenu(){
      if(localStorage.getItem("user") == null){
        return true;
      }else{
        return false;
      }
    }
}
