import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class CustomerService {
    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getCustomers() {
        return this._http.get(this.myAppUrl + 'api/Customer/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    getCustomerById(id: number) {
        return this._http.get(this.myAppUrl + "api/Customer/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveCustomer(Customer) {
        return this._http.post(this.myAppUrl + 'api/Customer/Create', Customer)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateCustomer(Customer) {
        return this._http.put(this.myAppUrl + 'api/Customer/edit', Customer)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteCustomer(id) {
        return this._http.delete(this.myAppUrl + "api/Customers/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}  