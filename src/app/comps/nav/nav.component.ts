
import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { UserService } from 'src/services/User.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  constructor(public us: UserService) { }

  items: MenuItem[] | undefined;

  position: string = 'top';//bottom/top/left/right

  ngOnInit() {
    this.items = [
      {
        icon: '../../../assets/pics/7.png',
        link: 'users'
      },
      {
        icon: '../../../assets/pics/5.png',
        link: 'personal'
      },
      {
        icon: '../../../assets/pics/4.png',
        link: 'register'
      },
      {
        icon: '../../../assets/pics/2.png',
        link: 'login'
      },
      {
        icon: '../../../assets/pics/6.png',
        link: 'trips'
      },
      {
        icon: '../../../assets/pics/3.png',
        link: 'home'
      }
    ];
  }
}