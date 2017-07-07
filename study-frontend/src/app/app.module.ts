import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule, ToastController } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { IonicStorageModule } from '@ionic/storage';
import {HttpModule} from '@angular/http';


import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { SignupPage } from '../pages/signup/signup';
import { SignupPasswordPage } from '../pages/signup-password/signup-password';
import { MainPage, TabIconTextContentPage } from '../pages/main/main';

@NgModule({
  declarations: [
    MyApp,
    HomePage, 
    SignupPage,
    SignupPasswordPage,
    MainPage,
    TabIconTextContentPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    IonicStorageModule.forRoot(), 
    HttpModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    SignupPage,
    SignupPasswordPage,
    MainPage,
    TabIconTextContentPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    ToastController,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}
