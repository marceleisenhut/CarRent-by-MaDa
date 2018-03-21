import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchCustomerComponent } from '../fetchcustomer/fetchcustomer.component';
import { CustomerService } from '../../services/customerservice.service';

@Component({
    selector: 'createcustomer',
    templateUrl: './AddCustomer.component.html'
})

export class createcustomer implements OnInit {
    customerForm: FormGroup;
    title: string = "erfassen";
    kundennummer: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _CustomerService: CustomerService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.kundennummer = this._avRoute.snapshot.params["id"];
        }

        this.customerForm = this._fb.group({
            kundennummer: [0, [Validators.required]],
            vorname: ['', [Validators.required]],
            nachname: ['', [Validators.required]],
            strasse: ['', [Validators.required]],
            ort: ['', [Validators.required]],
            telefonnummer: ['', [Validators.required]],
            email: ['']
        })
    }

    ngOnInit() {
        if (this.kundennummer > 0) {
            this.title = "bearbeiten";
            this.customerForm = this._fb.group({
                kundennummer: this.kundennummer
            })
            // this.customerForm.setValue({ vorname: 'test', nachname: 'test2' });
            this._CustomerService.getCustomerById(this.kundennummer).subscribe(resp => this.customerForm.setValue(resp), error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.customerForm.valid) {
            return;
        }

        if (this.title == "erfassen") {
            this._CustomerService.saveCustomer(this.customerForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "bearbeiten") {
            this._CustomerService.updateCustomer(this.customerForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-customer']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-customer']);
    }

   /* get vorname() { return this.customerForm.get('vorname'); }
    get nachname() { return this.customerForm.get('nachname'); }
    get strasse() { return this.customerForm.get('strasse'); }
    get ort() { return this.customerForm.get('ort'); } */
} 