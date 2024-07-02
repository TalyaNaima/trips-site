import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Trip } from 'src/classes/Trip';
import { UserService } from './User.service';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TripService implements OnInit {

  constructor(public http: HttpClient, public us: UserService) { }
  ngOnInit(): void {
    this.getAll()
  }

  basicUrl: string = 'https://localhost:7056/api/Trip'
  tripsList: Array<Trip> = new Array<Trip>()
  filteredTrips: Array<Trip> = new Array<Trip>()

  getAll() {
    this.http.get<Array<Trip>>(this.basicUrl)
      .subscribe(suc => {
        this.tripsList = suc.filter(trip => new Date(trip.tripDate!).getTime() >= Date.now());
        this.filteredTrips = this.tripsList
      },
        fail => {
          alert("failed to get all the trips")
        }
      )
  }

  getById(id: number = 0): Observable<Trip> {
    return this.http.get<Trip>(this.basicUrl + "/GetById/" + id)
  }

  updateTrip(t: Trip): Observable<Trip> {
    return this.http.put<Trip>(this.basicUrl, t)
  }
  
}
