import { Component, OnInit } from '@angular/core';
import { User } from 'src/classes/User';
import { UserService } from 'src/services/User.service';
import { Router } from '@angular/router';
import { InvitationService } from 'src/services/invitation.service';


@Component({
  selector: 'app-edit-details',
  templateUrl: '../register/register.component.html',
  styleUrls: ['../register/register.component.css']
})
export class EditDetailsComponent implements OnInit {

  constructor(public us: UserService, public r: Router, public is: InvitationService) { }

  ngOnInit(): void {
    this.cust = this.us.currentCust
  }

  cust: User = this.us.currentCust
  title: string = "edit"
  btnval: string = "save"

  //מקושר לקבצי כניסת משתמש חדש ומדובר בפונקצית עדכון
  register() {
    this.us.update(this.cust)
    this.r.navigate(['./personal'])
  }

  deleteUser() {
    this.is.getByUserId(this.us.currentCust.userId).subscribe(
      suc => {
        if (suc == null || suc.length == 0)
          this.us.delete().subscribe(
            s => {
              alert('bye bye...')
              this.us.currentCust = new User(0, '', '', '', '', '')
            }
          )
        else
          alert("you can't delete your subscription while you have ordered trips")
      }
    )
  }

}
