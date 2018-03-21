import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { CustomerService } from '../../services/customerservice.service';

@
Component({
    selector: 'fetchcustomer',
    templateUrl: './fetchCustomer.component.html'
})

export class FetchCustomerComponent {
    public empList: ICustomerData[];

    constructor(public http: Http, private _router: Router, private _CustomerService: CustomerService) {

        this.getCustomers();
    }

    getCustomers() {
        this._CustomerService.getCustomers().subscribe(data => this.empList = data);
    }

    delete(CustomerID) {
        var ans = confirm("Do you want to delete customer with Id: " + CustomerID);
        if (ans) {
            this._CustomerService.deleteCustomer(CustomerID).subscribe((data) => {
                    this.getCustomers();
                },
                error => console.error(error));
        }
    }
}

interface ICustomerData {
    kundennummer: number;
    vorname: string;
    nachname: string;
    strasse: string;
    ort: string;
    telefonnummer: string;
    email: string;
    erstellungsdatum: Date;
}