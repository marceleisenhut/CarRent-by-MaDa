import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ReservationService } from '../../services/reservationservice.service';

@
Component({
    selector: 'fetchreservation',
    templateUrl: './fetchreservation.component.html'
})

export class FetchReservationComponent {
    public resList: IReservationData[];

    constructor(public http: Http, private _router: Router, private _reservationService: ReservationService) {

        this.getReservationen();
    }

    getReservationen() {
        this._reservationService.getReservationen().subscribe(data => this.resList = data);
    }

    delete(ReservationID) {
        var ans = confirm("Do you want to delete customer with Id: " + ReservationID);
        if (ans) {
            this._reservationService.deleteReservation(ReservationID).subscribe((data) => {
                    this.getReservationen();
                },
                error => console.error(error));
        }
    }
}

interface IReservationData {
    reservationsnummer: number;
    auto: string;
    kunde: string;
    beginn: Date;
    ende: Date;
    erstellungsdatum: Date;
}