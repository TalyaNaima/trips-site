import { Component } from '@angular/core';
import { User } from 'src/classes/User';
import { UserService } from 'src/services/User.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(public c: UserService, public r: Router) { }

  deleteUser() {
    throw new Error('the button shouldnt show here.');
  }

  cust: User = new User()
  title: string = "welcome"
  btnval: string = "register"

  register() {
    this.c.login(this.cust.email, this.cust.password).subscribe(
      suc => {
        if (suc != null)
          alert("the user already exists, you may log in")
        else {
          this.c.register(this.cust)
          this.r.navigate(['../trips'])
        }
      }
    )
  }
}
