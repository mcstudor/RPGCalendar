import { Component, OnInit } from '@angular/core';
import { CalendarService } from '../service/calendar/calendar.service';

@Component({
  selector: 'app-game-calendar',
  templateUrl: './game-calendar.component.html',
  styleUrls: ['./game-calendar.component.css']
})
export class GameCalendarComponent implements OnInit {
  headRow: string[];
  units : string[][];

  calendarService : CalendarService
  constructor(calendarService : CalendarService) {
     this.calendarService = calendarService;
  }
  getTemplateFormat(){
    var cols = this.headRow.length;
    return `repeat(${cols}, 15%)`;
  } 


  ngOnInit() {
    this.headRow = this.calendarService.getHeadRow();
    this.units = this.calendarService.getUnits();
  }

}
