import { Injectable } from '@angular/core';
import {Http, Headers, RequestOptions} from '@angular/http';
import 'rxjs/Rx';

@Injectable()
export class Test {

constructor(public http: Http) { }


public test() : Promise<any>
{
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get('https://randomuser.me/api/', options)
    .map(res => res.json()).toPromise();
}
}