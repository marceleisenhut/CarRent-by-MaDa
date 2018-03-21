import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class ReservationService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getReservationen() {
        return this._http.get(this.myAppUrl + 'api/Reservation/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getReservationById(id: number) {
        return this._http.get(this.myAppUrl + "api/Reservation/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveReservation(Reservation) {
        return this._http.post(this.myAppUrl + 'api/Reservation/Create', Reservation)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateReservation(Reservation) {
        return this._http.put(this.myAppUrl + 'api/Reservation/Edit', Reservation)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteReservation(id) {
        return this._http.delete(this.myAppUrl + "api/Reservation/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}  