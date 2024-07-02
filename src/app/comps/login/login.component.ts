import { Component, OnInit } from '@angular/core';
import { User } from 'src/classes/User';
import { UserService } from 'src/services/User.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent{

  constructor(public c:UserService, public r:Router) {}
  
  cust: User=new User()
  async login(){
    this.c.login(this.cust.email, this.cust.password).subscribe(
      suc=>{
        this.c.currentCust=suc;        
        this.r.navigate(['../trips']) 
      },
      fail=>{
        this.r.navigate(['../register'])
      }
    )
  }
}
