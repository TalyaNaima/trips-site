import { Component, OnInit } from '@angular/core';
import { Trip } from 'src/classes/Trip';
import { UserService } from 'src/services/User.service';
import { InvitationService } from 'src/services/invitation.service';
import { TripService } from 'src/services/trip.service';
import { TypesService } from 'src/services/types.service';

@Component({
  selector: 'app-my-trips',
  templateUrl: '../all-trips/all-trips.component.html',
  styleUrls: ['../all-trips/all-trips.component.scss']
})
export class MyTripsComponent implements OnInit {
  constructor(public is: InvitationService, public us: UserService, public ts: TripService, public typeS: TypesService) { }
  myTrips: Array<Trip> = new Array<Trip>()

  ngOnInit(): void {
    this.is.getByUserId(this.us.currentCust.userId)
      .subscribe(suc => {
        this.is.InvitationList = suc;
        this.filterMy()
      },
        fail => {
          alert("failed to get all the invitation")
        })
    this.typeS.getAll()

  }

  filter1() {
    console.log(this.myTrips);

    // ממין מתוך הרשימה שלי לתוך הרשימה הממוינת את מה שבסוג הנבחר ובמחיר הרצוי
    this.ts.filteredTrips = this.myTrips.filter(t => (t.tripTypeId == this.selectedType || this.selectedType == 0) && (t.price! <= this.selectedPrice || this.selectedPrice == 0))
  }

  filterMy() {
    for (let i = 0; i < this.is.InvitationList.length; i++) {
      this.ts.getById(this.is.InvitationList[i].invitationTripId).subscribe(
        suc => {
          this.myTrips.push(suc)
          console.log(suc);

        }
      )
    }
    this.ts.filteredTrips = this.myTrips
  }

  getStyle(pic?: string) {
    const s1 = "../../../assets/pics/" + pic
    return 'url(' + s1 + ')'
  }

  link: string = "delete"
  isMine: boolean = true
  selectedType: number = 0;
  selectedPrice: number = 0;
}
