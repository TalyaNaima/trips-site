import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invitation } from 'src/classes/Invitation';


@Injectable({
  providedIn: 'root'
})
export class InvitationService {

  constructor(public http: HttpClient) { }

  basicUrl: string = 'https://localhost:7056/api/Invitation'
  InvitationList: Array<Invitation> = new Array<Invitation>()

  get(): Observable<Invitation> {
    return this.http.get<Invitation>(this.basicUrl)
  }

  getAll() {
    this.http.get<Array<Invitation>>(this.basicUrl)
      .subscribe(suc => {
        this.InvitationList = suc;
      },
        fail => {
          alert("failed to get all the invitation")
        })
  }

  getByUserId(userId: number = 0): Observable<Array<Invitation>> {
    return this.http.get<Array<Invitation>>(this.basicUrl + "/GetAllInvitationsToUser/" + userId)
  }

  post(invitation: Invitation): Observable<number> {
    return this.http.post<number>(this.basicUrl, invitation)
  }

  delete(UId: number = 0, TId: number = 0): Observable<boolean> {
    return this.http.delete<boolean>(this.basicUrl + "/" + UId + "/" + TId)
  }

}

