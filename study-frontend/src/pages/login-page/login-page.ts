import { Component, trigger, state, style, transition, animate, keyframes, ViewChild } from '@angular/core';
import { NavController, LoadingController, Grid, Slides, ToastController, Toast } from 'ionic-angular';
import { Storage } from '@ionic/storage';
import {Http, Headers, RequestOptions} from '@angular/http';
import {Account} from './../../services';
import { ResultStatus} from './../../communication';
import {SignupPage} from './../signup/signup';

@Component({
  selector: 'page-login',
  templateUrl: 'login-page.html'
})
export class LoginPage {
  @ViewChild(Slides) slides: Slides;

  email: string = '';


  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController, storage: Storage, public http: Http, public toastCtrl: ToastController) {
    storage.ready().then(() => {
    })
  }

  ngAfterViewInit()
  {
        this.slides.pager = false;
  }


  public signIn() {
    let loader = this.loadingCtrl.create({
      content: "Please wait...",
      duration: 3000
    });
    loader.present();
  }

    public validateEmail() {
    let toast: Toast;
    let toasts = Array<Toast>();
    let loader = this.loadingCtrl.create({
      content: "Please wait..."
    })
    let account = new Account(this.http);
    
    loader.present();
    

    account.emailValidate(this.email).then(data => {
      loader.dismiss();

      if(data.ResultStatus != ResultStatus.Successful)
      {
        data.Errors.forEach(element => {
          toast = this.toastCtrl.create({
            duration: 3000,
            position: 'bottom',
            message: element
          });
          toast.present();
        });
      } else {
          toast = this.toastCtrl.create({
            duration: 3000,
            position: 'bottom',
            message: 'Email is valid'
          });
          toast.present();
          this.navCtrl.push(SignupPage,
             {
               email: this.email
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
  
  public slideToSignUp()
  {
    this.slides.slideNext(500);
  }

    public slideToSignIn()
  {
    this.slides.slidePrev(500);
  }
}