import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmationAlarmComponent } from './confirmation-alarm.component';

describe('ConfirmationAlarmComponent', () => {
  let component: ConfirmationAlarmComponent;
  let fixture: ComponentFixture<ConfirmationAlarmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfirmationAlarmComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfirmationAlarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
