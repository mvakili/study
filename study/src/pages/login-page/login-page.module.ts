import { NgModule, ViewChild } from '@angular/core';
import { IonicModule } from 'ionic-angular';
import { LoginPage } from './login-page';
import { LoadingController, Slides } from 'ionic-angular';

@NgModule({
  declarations: [
    LoginPage,
  ],
  exports: [
    LoginPage
  ]
})
export class LoginPageModule {
  @ViewChild(Slides) slides: Slides;
  constructor()
  {
    
  }

}
