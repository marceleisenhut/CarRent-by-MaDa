import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchCarComponent } from '../fetchcar/fetchcar.component';
import { CarService } from '../../services/carservice.service';

@Component({
    selector: 'createcar',
    templateUrl: './Addcar.component.html'
})

export class createcar implements OnInit {
    carForm: FormGroup;
    title: string = "erfassen";
    id: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _carService: CarService, private _router: Router) {
        if (this._avRoute.snapshot.params["id"]) {
            this.id = this._avRoute.snapshot.params["id"];
        }

        this.carForm = this._fb.group({
            id: [0, [Validators.required]],
            kennzeichen: ['', [Validators.required]],
            marke: ['', [Validators.required]],
            modell: ['', [Validators.required]],
            kilometerstand: ['', [Validators.required]],
            baujahr: ['', [Validators.required]],
            anzahlsitze: [''],
            anzahltueren: [''],
            leistunginps: [''],
            klasse: ['']
        })
    }

    ngOnInit() {
        if (this.id > 0) {
            this.title = "bearbeiten";
            this.carForm = this._fb.group({
                id: this.id
            })
            // this.carForm.setValue({ vorname: 'test', nachname: 'test2' });
            this._carService.getCarById(this.id).subscribe(resp => this.carForm.setValue(resp), error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.carForm.valid) {
            return;
        }

        if (this.title == "erfassen") {
            this._carService.saveCar(this.carForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-car']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "bearbeiten") {
            this._carService.updateCar(this.carForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/fetch-car']);
                }, error => this.errorMessage = error)
        }
    }

    cancel() {
        this._router.navigate(['/fetch-car']);
    }

   /* get vorname() { return this.carForm.get('vorname'); }
    get nachname() { return this.carForm.get('nachname'); }
    get strasse() { return this.carForm.get('strasse'); }
    get ort() { return this.carForm.get('ort'); } */
} 