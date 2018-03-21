import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { CarService } from '../../services/carservice.service';

@Component({
    selector: 'fetchcar',
    templateUrl: './fetchcar.component.html'
})

export class FetchCarComponent {
    public carList: ICarData[];

    constructor(public http: Http, private _router: Router, private _CarService: CarService) {

        this.getCars();
    }

    getCars() {
        this._CarService.getCars().subscribe(data => this.carList = data);
        // Fixe Daten zum Test
        
    }

    delete(CarID) {
        var ans = confirm("Do you want to delete car with Id: " + CarID);
        if (ans) {
            this._CarService.deleteCar(CarID).subscribe((data) => {
                    this.getCars();
                },
                error => console.error(error));
        }
    }
}

interface ICarData {
    id: number;
    kennzeichen: string;
    marke: string;
    modell: string;
    baujahr: string;
    klasse: string;
    kilometerstand: number;
    anzahlsitze: number;
    anzahltueren: number;
    leistunginps: number;
    erstellungsdatum: Date;
}