import { NgModule } from '@angular/core';
import { IonicModule } from 'ionic-angular';
import { LoginPage } from './login-page';
import { LoadingController } from 'ionic-angular';

@NgModule({
  declarations: [
    LoginPage,
  ],
  exports: [
    LoginPage
  ]
})
export class LoginPageModule {}
