import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './comps/home-page/home-page.component';
import { LoginComponent } from './comps/login/login.component';
import { RegisterComponent } from './comps/register/register.component';
import { AllTripsComponent } from './comps/all-trips/all-trips.component';
import { PersonalAreaComponent } from './comps/personal-area/personal-area.component';
import { TripComponent } from './comps/trip-details/trip-details.component';
import { EditDetailsComponent } from './comps/edit-details/edit-details.component';
import { MyTripsComponent } from './comps/my-trips/my-trips.component';
import { AllUserComponent } from './comps/all-user/all-user.component';
import { DeleteComponent } from './comps/delete/delete.component';

const routes: Routes = [
  { path: 'home', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'trips', component: AllTripsComponent, children: [
      { path: 'detail/:Id', component: TripComponent }
    ]
  },
  { path: 'personal', component: PersonalAreaComponent },
  { path: 'edit', component: EditDetailsComponent },
  {
    path: 'mytrips', component: MyTripsComponent, children: [
      { path: 'delete/:Id', component: DeleteComponent }
    ]
  },
  { path: 'users', component: AllUserComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
