import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Type } from 'src/classes/Type';

@Injectable({
  providedIn: 'root'
})
export class TypesService implements OnInit {

  constructor(public http: HttpClient) { }

  basicUrl: string = 'https://localhost:7056/api/TypeTrip'
  typeList: Array<Type> = new Array<Type>()

  ngOnInit(): void {
    this.getAll
  }

  getAll() {
    this.http.get<Array<Type>>(this.basicUrl)
      .subscribe(suc => {
        this.typeList = suc
        console.log(this.typeList);
      },
        fail => {
          alert("failed to get types of trips")
        })
  }
}
