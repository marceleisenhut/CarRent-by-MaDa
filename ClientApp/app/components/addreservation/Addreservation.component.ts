import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchReservationComponent } from '../fetchreservation/fetchreservation.component';
import { ReservationService } from '../../services/reservationservice.service';

@Component({
    selector: 'createreservation',
    templateUrl: './Addreservation.component.html'
})

export class createreservation implements OnInit {
    reservationForm: FormGroup;
    title: string = "erfassen";
    reservationsnummer: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _reservationService: ReservationService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.reservationsnummer = this._avRoute.snapshot.params["id"];
        }

        this.reservationForm = this._fb.group({
            reservationsnummer: [0, [Validators.required]],
            auto: ['', [Validators.required]],
            kunde: ['', [Validators.required]],
            beginn: ['', [Validators.required]],
            ende: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.reservationsnummer > 0) {
            this.title = "bearbeiten";
            this.reservationForm = this._fb.group({
                reservationsnummer: this.reservationsnummer
            })
            // this.reservationloyeeForm.setValue({ vorname: 'test', nachname: 'test2' });
            this._reservationService.getReservationById(this.reservationsnummer).subscribe(resp => this.reservationForm.setValue(resp), error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.reservationForm.valid) {
            return;
        }

        if (this.title == "erfassen") {
            this._reservationService.saveReservation(this.reservationForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-reservation']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "bearbeiten") {
            this._reservationService.updateReservation(this.reservationForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-reservation']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-reservation']);
    }

   /* get vorname() { return this.reservationloyeeForm.get('vorname'); }
    get nachname() { return this.reservationloyeeForm.get('nachname'); }
    get strasse() { return this.reservationloyeeForm.get('strasse'); }
    get ort() { return this.reservationloyeeForm.get('ort'); } */
} 