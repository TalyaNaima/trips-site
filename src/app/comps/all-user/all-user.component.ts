import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/services/User.service';

@Component({
  selector: 'app-all-user',
  templateUrl: './all-user.component.html',
  styleUrls: ['./all-user.component.css']
})
export class AllUserComponent implements OnInit{
  constructor(public us:UserService){}
  ngOnInit(): void {
    this.us.getAll()
  }
}
