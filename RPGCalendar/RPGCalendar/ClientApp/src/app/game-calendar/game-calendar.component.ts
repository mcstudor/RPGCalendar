import { Component, OnInit } from '@angular/core';
import { CalendarService } from '../service/calendar/calendar.service';

@Component({
  selector: 'app-game-calendar',
  templateUrl: './game-calendar.component.html',
  styleUrls: ['./game-calendar.component.css']
})
export class GameCalendarComponent implements OnInit {
  units : string[];
  headRow : string[];
  monthName : string;
  calendarService : CalendarService
  constructor(calendarService : CalendarService) {
     this.calendarService = calendarService;
  }
  getTemplateFormat(){
    var cols = this.calendarService.col;
    return `repeat(${cols},  auto)`;
  } 


  ngOnInit() {
    this.units = this.calendarService.getUnits();
    this.headRow = this.calendarService.getHeadRow();
    this.monthName = this.calendarService.getMonthName();
  }

}
