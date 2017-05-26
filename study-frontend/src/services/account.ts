import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import {ApiResult, GenericApiResult, Request} from './../communication';

@Injectable()
export class Account {

    constructor(public http: Http) { }

    public emailValidate(email: string) : Promise<ApiResult>
    {
        let req = new Request(this.http);
        let result = req.post<GenericApiResult<number>>('account', 'emailValidate', email);
        return result;
    }
}