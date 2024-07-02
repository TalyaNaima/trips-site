import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-personal-area',
  templateUrl: './personal-area.component.html',
  styleUrls: ['./personal-area.component.css']
})
export class PersonalAreaComponent {
  constructor(public r: Router) { }
  myTripsLink() {
    this.r.navigate(['../mytrips'])
  }
  updateLink() {
    this.r.navigate(['../edit'])
  }

}
