import { Component, trigger, state, style, transition, animate, keyframes, ViewChild } from '@angular/core';
import { NavController, LoadingController, Grid, Slides } from 'ionic-angular';
import { Storage } from '@ionic/storage';


@Component({
  selector: 'page-login',
  templateUrl: 'login-page.html'
})
export class LoginPage {
  @ViewChild(Slides) slides: Slides;

  constructor(public navCtrl: NavController, public loadingCtrl: LoadingController, storage: Storage) {
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
  
  public slideToSignUp()
  {
    this.slides.slideNext(500);
  }

    public slideToSignIn()
  {
    this.slides.slidePrev(500);
  }
}