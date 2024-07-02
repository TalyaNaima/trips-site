import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/services/User.service';
import { InvitationService } from 'src/services/invitation.service';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.scss']
})
export class DeleteComponent {
  constructor(public ar: ActivatedRoute, public r: Router, public is: InvitationService, public us: UserService) { }

  close() {
    this.r.navigate(['../../mytrips'])
  }

  deleteInvitation() {
    this.ar.params.subscribe(
      data => {
        console.log(data['Id']);
        this.is.delete(this.us.currentCust.userId, data['Id']).subscribe(
          suc => {
            if (suc) {
              this.close()
              alert("you have deleted your invitation")
            }
            else {
              alert("something went wrong...")
              this.close()
            }
          }
          , fail => {
            alert("something went wrong...")
            console.log(fail);
            this.close()
          }
        )
      }
    )
  }

}
