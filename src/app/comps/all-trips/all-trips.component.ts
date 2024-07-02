import { Component, OnInit } from '@angular/core';
import { TripService } from 'src/services/trip.service';
import { TypesService } from 'src/services/types.service';

@Component({
  selector: 'app-all-trips',
  templateUrl: './all-trips.component.html',
  styleUrls: ['./all-trips.component.scss']
})
export class AllTripsComponent implements OnInit {
  constructor(public ts: TripService, public typeS: TypesService) { }

  ngOnInit(): void {
    this.ts.getAll()
    this.typeS.getAll()
  }

  filter1() {
    this.ts.filteredTrips = this.ts.tripsList.filter(o => o.tripTypeId == this.selectedType || this.selectedType == 0)
  }

  getStyle(pic?: string) {
    const s1 = "../../../assets/pics/" + pic
    return 'url(' + s1 + ')'
  }

  link: string = "detail"
  isMine: boolean = false
  selectedType: number = 0;
  selectedPrice: number = 0;
}
