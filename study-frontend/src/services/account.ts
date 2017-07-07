import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import {ApiResult, GenericApiResult, Request} from './../communication';

@Injectable()
export class Account {

    constructor(public http: Http) { }

    public emailValidate(email: string) : Promise<ApiResult>
    {
        let req = new Request(this.http);
        let result = req.post<ApiResult>('account', 'emailValidate', email);
        return result;
    }

    public usernameValidate(username: string) : Promise<ApiResult>
    {
        let req = new Request(this.http);
        let result = req.post<ApiResult>('account', 'usernameValidate', username);
        return result;
    }

    public register(username: string, password: string, email: string, passwordConfirm: string) : Promise<ApiResult>
    {
        let req = new Request(this.http);
        let result = req.post<ApiResult>('account', 'register', {Username: username, Password: password, Email: email, PasswordConfirm: passwordConfirm});
        return result;
    }

    public signIn(username: string, password: string, rememberMe: boolean = true) : Promise<ApiResult>
    {
        let req = new Request(this.http);
        let result = req.post<ApiResult>('account', 'signIn', {Username: username, Password: password, RememberMe: rememberMe});
        return result;
    }

        public amILoggedIn() : Promise<GenericApiResult<boolean>>
    {
        let req = new Request(this.http);
        let result = req.post<GenericApiResult<boolean>>('account', 'AmILoggedIn');
        return result;
    }
}