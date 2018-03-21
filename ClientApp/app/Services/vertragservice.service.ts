import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class VertragService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getVertrage() {
        return this._http.get(this.myAppUrl + 'api/Vertrag/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getVertragById(id: number) {
        return this._http.get(this.myAppUrl + "api/Vertrag/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveVertrag(Vertrag) {
        return this._http.post(this.myAppUrl + 'api/Vertrag/Create', Vertrag)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateVertrag(Vertrag) {
        return this._http.put(this.myAppUrl + 'api/Vertrag/Edit', Vertrag)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteVertrag(id) {
        return this._http.delete(this.myAppUrl + "api/Vertrag/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}  