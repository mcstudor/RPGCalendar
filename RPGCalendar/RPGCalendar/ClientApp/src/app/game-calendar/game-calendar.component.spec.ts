import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameCalendarComponent } from './game-calendar.component';

describe('GameCalendarComponent', () => {
  let component: GameCalendarComponent;
  let fixture: ComponentFixture<GameCalendarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameCalendarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
