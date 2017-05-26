import { Injectable } from '@angular/core';
import {Http, Headers, RequestOptions, Response} from '@angular/http';
import 'rxjs/Rx';
import {ApiResult, GenericApiResult, Request} from './../communication';

@Injectable()
export class Test {

    constructor(public http: Http) { }


    public test() : Promise<GenericApiResult<number>>
    {
        let req = new Request(this.http);
        let result = req.post<GenericApiResult<number>>('home', 'Post', {i : 3, j : 4});
        return result;
    }
}