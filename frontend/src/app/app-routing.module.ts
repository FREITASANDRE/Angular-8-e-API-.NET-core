import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';
import { GuardGuard } from './guard/guard.guard';


const routes: Routes = [
  {path: 'home', component : HomeComponent , canActivate : [GuardGuard]},
  {path: 'login', component : LoginComponent},
  {path: 'user', component : UserComponent ,  canActivate : [GuardGuard]},
  {path: 'user/:id', component : UserComponent, canActivate : [GuardGuard]},
  {path: '', component : LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
