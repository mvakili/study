import { Component } from '@angular/core';
import { NavController, LoadingController, Grid, Slides, ToastController, Toast, IonicPage, NavParams } from 'ionic-angular';
import {Http} from '@angular/http';
import { Storage } from '@ionic/storage';
import {Account} from './../../services';
import { ResultStatus} from './../../communication';
import {HomePage} from './../home/home';
import {SignupPasswordPage} from './../signup-password/signup-password';

/**
 * Generated class for the SignupPage page.
 *
 * See http://ionicframework.com/docs/components/#navigation for more info
 * on Ionic pages and navigation.
 */
@IonicPage()
@Component({
  selector: 'page-signup',
  templateUrl: 'signup.html',
})
export class SignupPage {
  email: string;
  username: string;

  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController, storage: Storage, public http: Http, public toastCtrl: ToastController, public navParams: NavParams) {
    if (navParams.get('email') == undefined)
    {
      navCtrl.popTo('HomePage');
    }
    this.email = navParams.get('email');
  }


   public usernameValidate() {
    let account = new Account(this.http);

    let loader = this.loadingCtrl.create({
      content: "Please wait..."
    })
    
    loader.present();
    

    account.usernameValidate(this.username).then(data => {
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
        this.navCtrl.push(SignupPasswordPage,
          {
            email: this.email,
            username: this.username
          }
        );
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
