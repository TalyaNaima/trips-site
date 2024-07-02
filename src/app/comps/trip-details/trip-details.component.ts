import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Trip } from 'src/classes/Trip';
import { UserService } from 'src/services/User.service';
import { TripService } from 'src/services/trip.service';
import { InvitationService } from 'src/services/invitation.service';
import { Invitation } from 'src/classes/Invitation';


@Component({
  selector: 'app-trip',
  templateUrl: './trip-details.component.html',
  styleUrls: ['./trip-details.component.css']
})
export class TripComponent implements OnInit {

  constructor(public ar: ActivatedRoute, public r: Router, public ts: TripService, public us: UserService, public is: InvitationService) { }
  t: Trip = new Trip()
  invite: Invitation = new Invitation()
  open: boolean = false
  tickets: number = 0

  ngOnInit(): void {
    this.ar.params.subscribe(
      data => {
        this.ts.getById(data['Id']).subscribe(
          suc => {
            this.t = suc
          }
        )
      }
    )
  }

  openOrder() {
    if (this.us.currentCust.email != '')
      this.open = true
    else
      alert("you are not connected")

  }

  getStyle(pic?: string) {
    const s1 = "../../../assets/pics/" + pic
    return 'url(' + s1 + ')'
  }

  close() {
    this.r.navigate(['../../trips'])
  }

  order() {
    this.invite.invitationUserId = this.us.currentCust.userId
    this.invite.invitationTripId = this.t.tripId
    this.invite.placeNumber = this.tickets
    this.is.post(this.invite).subscribe(
      suc => {
        if (suc != -1) {
          alert("you have succesfully singed up to the trip")
          this.close()
        }
        else {
          alert("there aren't enough places in the trip for your order")
        }
      },
      fail => {
        alert(fail)
      }
    )
  }
  
}