import { Component, trigger, state, style, transition, animate, keyframes, ViewChild } from '@angular/core';
import { NavController, LoadingController, Grid, Slides } from 'ionic-angular';
import { Storage } from '@ionic/storage';
import {Http, Headers, RequestOptions} from '@angular/http';
import {Account} from './../../services';

@Component({
  selector: 'page-login',
  templateUrl: 'login-page.html'
})
export class LoginPage {
  @ViewChild(Slides) slides: Slides;

  email: string = '';


  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController, storage: Storage, public http: Http) {
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
    let loader = this.loadingCtrl.create({
      content: "Please wait..."
    })
    loader.present();

    let account = new Account(this.http);
    account.emailValidate(this.email).then(data => {
      loader.dismiss();
      
    }).catch(err => {
      loader.dismiss();
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