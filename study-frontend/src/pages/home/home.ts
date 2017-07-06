import { Component, trigger, state, style, transition, animate, keyframes, ViewChild } from '@angular/core';
import { NavController, LoadingController, Grid, Slides, ToastController, Toast } from 'ionic-angular';
import { Storage } from '@ionic/storage';
import {Http, Headers, RequestOptions} from '@angular/http';
import {Account} from './../../services';
import { ResultStatus} from './../../communication';
import {SignupPage} from './../signup/signup';

@Component({
  selector: 'home-page',
  templateUrl: 'home.html'
})
export class HomePage {
  @ViewChild(Slides) slides: Slides;

  email: string = '';
  username: string;
  password: string;

  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController, storage: Storage, public http: Http, public toastCtrl: ToastController) {
    storage.ready().then(() => {
    })
  }

  ngAfterViewInit()
  {
        this.slides.pager = false;
  }

  public signIn() {
    let account = new Account(this.http);

    let toast: Toast;
    let loader = this.loadingCtrl.create({
      content: "Please wait..."
    })
    
    loader.present();
    

    account.signIn(this.username, this.password).then(data => {
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

  public emailValidate() {
    let account = new Account(this.http);

    let toast: Toast;
    let loader = this.loadingCtrl.create({
      content: "Please wait..."
    })
    
    loader.present();
    

    account.emailValidate(this.email).then(data => {
      loader.dismiss();
        data.Messages.forEach(element => {
          this.toastCtrl.create({
            duration: 3000,
            position: 'bottom',
            message: element
          }).present();
        });
      if(data.ResultStatus = ResultStatus.Successful)
      {
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