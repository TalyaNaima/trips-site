import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { User } from 'src/classes/User';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService implements OnInit {

  constructor(public http: HttpClient, public r: Router) { }
  ngOnInit(): void {
    this.getAll()
  }

  basicUrl: string = 'https://localhost:7056/api/User'
  currentCust: User = new User(0, '', '', '', '', '')
  isAdmin: boolean = false
  allUsers: Array<User> = new Array<User>()

  login(email?: string, password?: string): Observable<User> {
    let adm = "" + localStorage.getItem("admin")
    let adm1 = JSON.parse(adm)
    if (adm1.email == email && adm1.password == password)
      this.isAdmin = true
    else
      this.isAdmin = false
    return this.http.get<User>(this.basicUrl + '/' + email + '/' + password)
  }

  register(cust: User) {
    this.http.post<User>(this.basicUrl, cust)
      .subscribe(suc => {
        this.currentCust = suc
      },
        fail => {
          alert(fail.message)
        })
  }

  update(cust: User) {
    this.http.put<User>(this.basicUrl, cust)
      .subscribe(suc => {
        this.currentCust = suc
      },
        fail => {
          alert(fail.message)
        })
  }

  getAll() {
    this.http.get<Array<User>>(this.basicUrl).subscribe(
      suc => {
        this.allUsers = suc
        console.log(this.allUsers);

      }
    )
  }

  delete(): Observable<boolean> {
    return this.http.delete<boolean>(this.basicUrl + '/' + this.currentCust.userId)
  }
  
}
