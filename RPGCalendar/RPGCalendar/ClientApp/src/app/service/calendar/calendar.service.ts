import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalendarService {
  getMonthName(): string {
    throw new Error("Method not implemented.");
  }
  constructor() { }
  days : number = 30;
  col : number = this.getHeadRow.length;
  rows : number = Math.ceil(this.days / this.col);
  getUnits() : string[][]{
    // var units : string[][];
    // var i = 0;
    // var j = 0;
    // for( var day = 1; day<31; day++){
    //   units[i][j] = String(day);
    //   j++;
    //   if(j>=this.getHeadRow.length){
    //     i++;
    //     j=0;
    //   }
    // }
    // for(j; j<this.getHeadRow.length; j++){
    //   units[i][j] = " ";
    // }
    // return units;
    var row1 = ["1" , "2" , "3" , "4" , "5" , "6" , "7"];
    var row2 = ["8" , "9" , "10" , "11" , "12" , "13" , "14"];
    var row3 = ["15" , "16" , "17" , "18" , "19" , "20", " "];
    return [row1, row2, row3];
  }

  getHeadRow() : string[] {
    return ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
  }
}
