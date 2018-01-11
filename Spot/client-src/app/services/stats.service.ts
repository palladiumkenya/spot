import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import {Observable} from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import {Faciltiy} from '../model/facility';

@Injectable()
export class StatsService {

    private _url = './api/stats';
    private _http: HttpClient;

    public constructor(http: HttpClient) {
        this._http = http;
    }

    public getSites(): Observable<Faciltiy[]> {
        return this._http.get<Faciltiy[]>(this._url)
            .catch(this.handleError);
    }

    public getSitesCount(): Observable<number> {
        return this._http.get<number>(this._url + '/count')
            .catch(this.handleError);
    }

    private handleError(err: HttpErrorResponse) {
        return Observable.throw(err.message);
    }
}
