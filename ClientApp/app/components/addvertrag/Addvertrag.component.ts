import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchVertragComponent } from '../fetchvertrag/fetchvertrag.component';
import { VertragService } from '../../services/vertragservice.service';

@Component({
    selector: 'createvertrag',
    templateUrl: './Addvertrag.component.html'
})

export class createvertrag implements OnInit {
    vertragForm: FormGroup;
    title: string = "erfassen";
    reservationsnummer: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _vertragService: VertragService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.reservationsnummer = this._avRoute.snapshot.params["id"];
        }

        this.vertragForm = this._fb.group({
            vertragsnummer: [0, [Validators.required]],
            auto: ['', [Validators.required]],
            kunde: ['', [Validators.required]],
            beginn: ['', [Validators.required]],
            ende: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.reservationsnummer > 0) {
            this.title = "bearbeiten";
            this.vertragForm = this._fb.group({
                vertragsnummer: this.reservationsnummer
            })
            // this.vertragloyeeForm.setValue({ vorname: 'test', nachname: 'test2' });
            this._vertragService.getVertragById(this.reservationsnummer).subscribe(resp => this.vertragForm.setValue(resp), error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.vertragForm.valid) {
            return;
        }

        if (this.title == "erfassen") {
            this._vertragService.saveVertrag(this.vertragForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-vertrag']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "bearbeiten") {
            this._vertragService.updateVertrag(this.vertragForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-vertrag']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-vertrag']);
    }

   /* get vorname() { return this.vertragForm.get('vorname'); }
    get nachname() { return this.vertragForm.get('nachname'); }
    get strasse() { return this.vertragForm.get('strasse'); }
    get ort() { return this.vertragForm.get('ort'); } */
} 