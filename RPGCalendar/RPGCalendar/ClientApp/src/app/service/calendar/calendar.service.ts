import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalendarService {
  getMonthName(): string {
    throw new Error("Method not implemented.");
  }
  constructor() { }
  headRow : Array<string> = new Array<string>("Selday", "Tyrday", "Janday", "Keleday", "Mystraday", "Lathday", "Istiday", "Suneday", "Ogday", "Akaday"); 
  monthName : string = "Tarsakh"
  days : number = 30;
  col : number = this.headRow.length;
  rows : number = Math.ceil(this.days / this.col);
  getUnits() : string[] {
    var units: Array<string>;
    units = new Array<string>();
    var day = 1;
    for(var i = 0; i<this.days; i++){
      units.push(String(day));
      day++;
    };
    return units;
  }

  getHeadRow() : Array<string> {
    return this.headRow;
  }

  getMonthName() : string {
    return this.monthName;
  }


}
