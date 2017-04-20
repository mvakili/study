import { Component, trigger, state, style, transition, animate, keyframes } from '@angular/core';
import { NavController, LoadingController } from 'ionic-angular';
 
@Component({
  selector: 'page-login',
  templateUrl: 'login-page.html',
  styles: ['']
})
export class LoginPage {
 
 
  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController) {
 
  }


  public signIn()
  {
    let loader = this.loadingCtrl.create({
      content: "Please wait...",
      duration: 3000
    });
    loader.present();
  }
 
}