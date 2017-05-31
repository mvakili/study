import { Injectable } from '@angular/core';
import {Http, Headers, RequestOptions, Response} from '@angular/http';
import 'rxjs/Rx';


export class Request {
    constructor(public http: Http) {
    }

    post<R>(controller: string, method: string, params: any = null) : Promise<R>{

        if(typeof params == "string" || params instanceof String)
        {
            params = '"'+params+'"';
        }
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers, withCredentials: true});
        return this.http.post('http://localhost:49901/api/'+controller+'/'+ method, params , options)
        .map<Response,R>(res => res.json()).toPromise();
    }
}