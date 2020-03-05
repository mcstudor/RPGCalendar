import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentAccountComponent } from './component-account.component';

describe('ComponentAccountComponent', () => {
  let component: ComponentAccountComponent;
  let fixture: ComponentFixture<ComponentAccountComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ComponentAccountComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ComponentAccountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
