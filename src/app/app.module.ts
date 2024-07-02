import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TripComponent } from './comps/trip-details/trip-details.component';
import { HomePageComponent } from './comps/home-page/home-page.component';
import { LoginComponent } from './comps/login/login.component';
import { RegisterComponent } from './comps/register/register.component';
import { AllTripsComponent } from './comps/all-trips/all-trips.component';

import { PersonalAreaComponent } from './comps/personal-area/personal-area.component';
import { NavComponent } from './comps/nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { DockModule } from 'primeng/dock';
import { EditDetailsComponent } from './comps/edit-details/edit-details.component';
import { MyTripsComponent } from './comps/my-trips/my-trips.component';
import { AdminComponent } from './comps/admin/admin.component';
import { AllUserComponent } from './comps/all-user/all-user.component';
import { DeleteComponent } from './comps/delete/delete.component';

@NgModule({
  declarations: [
    AppComponent,
    TripComponent,
    HomePageComponent,
    LoginComponent,
    RegisterComponent,
    AllTripsComponent,
    PersonalAreaComponent,
    NavComponent,
    EditDetailsComponent,
    MyTripsComponent,
    AdminComponent,
    AllUserComponent,
    DeleteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgbModule,
    FormsModule,
    HttpClientModule,

    DockModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
