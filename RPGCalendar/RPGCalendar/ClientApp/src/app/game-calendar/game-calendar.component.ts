import { Component, OnInit } from '@angular/core';
import { DomSanitizer , SafeStyle } from '@angular/platform-browser';

@Component({
  selector: 'app-game-calendar',
  templateUrl: './game-calendar.component.html',
  styleUrls: ['./game-calendar.component.css']
})
export class GameCalendarComponent implements OnInit {
  headRow: string[] = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
  row1: string[] = ["1" , "2" , "3" , "4" , "5" , "6" , "7"];
  row2: string[] = ["8" , "9" , "10" , "11" , "12" , "13" , "14"];
  row3: string[] = ["15" , "16" , "17" , "18" , "19" , "20", " "];
  units : string[][] = [this.row1,this.row2 , this.row3]
  cols: number  = 4;
  constructor(private sanitizer: DomSanitizer) {
     
  }

  getColumnTemplate : SafeStyle  = this.sanitizer.bypassSecurityTrustStyle(`grid-template-columns: repeat(4" , "auto)`);

  ngOnInit() {
  }

}
