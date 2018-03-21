import { NgModule } from '@angular/core';
import { CustomerService } from './services/customerservice.service';
import { CarService } from './services/carservice.service';
import { ReservationService } from './services/reservationservice.service';
import { VertragService } from './services/vertragservice.service';
// anfügen
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchCustomerComponent } from './components/fetchCustomer/fetchCustomer.component';
import { createcustomer } from './components/addcustomer/Addcustomer.component';
import { createcar } from './components/addcar/Addcar.component';
import { FetchCarComponent } from './components/fetchcar/fetchcar.component';
import { FetchReservationComponent } from './components/fetchreservation/fetchreservation.component';
import { FetchVertragComponent } from './components/fetchvertrag/fetchvertrag.component';
import { createreservation } from './components/addreservation/Addreservation.component';
import { createvertrag } from './components/addvertrag/Addvertrag.component';
// anfügen

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchCustomerComponent,
        createcustomer,
        createcar,
        createreservation,
        createvertrag,
        FetchCarComponent,
        FetchReservationComponent,
        FetchVertragComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-customer', component: FetchCustomerComponent },
            { path: 'register-customer', component: createcustomer },
            { path: 'customer/edit/:id', component: createcustomer },
            { path: 'fetch-car', component: FetchCarComponent },
            { path: 'register-car', component: createcar },
            { path: 'car/edit/:id', component: createcar },
            { path: 'fetch-reservation', component: FetchReservationComponent },
            { path: 'register-reservation', component: createreservation },
            { path: 'reservation/edit/:id', component: createreservation },
            { path: 'fetch-vertrag', component: FetchVertragComponent },
            { path: 'register-vertrag', component: createvertrag },
            { path: 'vertrag/edit/:id', component: createvertrag },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [CustomerService, CarService, ReservationService, VertragService]
})
export class AppModuleShared {
}  