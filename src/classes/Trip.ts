// import { Time } from "@angular/common";

export class Trip{
    constructor(
        public tripId?:number,
        public yhad?:string,
        public tripTypeId?:number,
        public tripTypeName?:number,
        public tripDate?:Date,
        // public leavingHour?:Time,
        public tripTime?:number,
        public tripDuration?:number,
        public tripEmptyPlace?:number,
        public price?:number,
        public picture?:string,
        public isFirstAid?:boolean

        ){

    }
}
