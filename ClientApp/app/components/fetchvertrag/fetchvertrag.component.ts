import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { VertragService } from '../../services/vertragservice.service';

@
Component({
    selector: 'fetchvertrag',
    templateUrl: './fetchvertrag.component.html'
})

export class FetchVertragComponent {
    public verList: IVertragData[];

    constructor(public http: Http, private _router: Router, private _vertragService: VertragService) {

        this.getvertrage();
    }

    getvertrage() {
        this._vertragService.getVertrage().subscribe(data => this.verList = data);
    }

    delete(vertragID) {
        var ans = confirm("Do you want to delete customer with Id: " + vertragID);
        if (ans) {
            this._vertragService.deleteVertrag(vertragID).subscribe((data) => {
                    this.getvertrage();
                },
                error => console.error(error));
        }
    }
}

interface IVertragData {
    reservationsnummer: number;
    auto: string;
    kunde: string;
    beginn: Date;
    ende: Date;
    erstellungsdatum: Date;
}