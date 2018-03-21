import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class CarService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getCars() {
        return this._http.get(this.myAppUrl + 'api/Car/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCarById(id: number) {
        return this._http.get(this.myAppUrl + "api/Car/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveCar(Car) {
        return this._http.post(this.myAppUrl + 'api/Car/Create', Car)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateCar(Car) {
        return this._http.put(this.myAppUrl + 'api/Car/Edit', Car)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteCar(id) {
        return this._http.delete(this.myAppUrl + "api/Car/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}  