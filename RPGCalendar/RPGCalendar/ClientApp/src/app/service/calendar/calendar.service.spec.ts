import { TestBed } from '@angular/core/testing';

import { CalendarService} from './calendar.service';

describe('CalendarServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CalendarService = TestBed.get(CalendarService);
    expect(service).toBeTruthy();
  });
});
