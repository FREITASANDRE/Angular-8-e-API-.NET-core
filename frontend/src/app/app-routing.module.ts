import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { UserComponent } from './user/user.component';


const routes: Routes = [
  {path: 'home', component : HomeComponent},
  {path: 'login', component : LoginComponent},
  {path: 'user', component : UserComponent},
  {path: 'user/:id', component : UserComponent},
  {path: '', component : LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
