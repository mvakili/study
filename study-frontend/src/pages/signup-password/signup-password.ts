import { Component } from '@angular/core';
import { NavController, LoadingController, Grid, Slides, ToastController, Toast, IonicPage, NavParams } from 'ionic-angular';
import {Http} from '@angular/http';
import { Storage } from '@ionic/storage';
import {Account} from './../../services';
import { ResultStatus} from './../../communication';
import {HomePage} from './../home/home';
import {SignupPage} from './../signup/signup';
import {MainPage} from './../main/main';
/**
 * Generated class for the SignupPasswordPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */
@IonicPage()
@Component({
  selector: 'page-signup-password',
  templateUrl: 'signup-password.html',
})
export class SignupPasswordPage {
  email: string;
  username: string;
  password: string;
  passwordConfirm: string;

  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController, storage: Storage, public http: Http, public toastCtrl: ToastController, public navParams: NavParams) {
    if (navParams.get('email') == undefined)
    {
      navCtrl.popTo('HomePage');
    }
    this.email = navParams.get('email');

    if (navParams.get('username') == undefined)
    {
      navCtrl.popTo(SignupPage);
    }
    this.username = navParams.get('username');
  }

  public signUp() {
    let account = new Account(this.http);

    let toast: Toast;
    let loader = this.loadingCtrl.create({
      content: "Please wait..."
    })
    
    loader.present();
    

    account.register(this.username, this.password, this.email, this.passwordConfirm).then(data => {
      loader.dismiss();
      data.Messages.forEach(element => {
        this.toastCtrl.create({
          duration: 3000,
          position: 'bottom',
          message: element
        }).present();
      });
      if(data.ResultStatus == ResultStatus.Successful)
      {
        this.navCtrl.setRoot(MainPage);
      }

    }).catch(err => {
      loader.dismiss();
      this.toastCtrl.create({
        duration: 3000,
        position: 'bottom',
        message: 'Couldn\'t connect to server'
      }).present();
    });
    
  }

}
