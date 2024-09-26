import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CookieInformationComponent } from './cookie-information.component';

describe('CookieInformationComponent', () => {
  let component: CookieInformationComponent;
  let fixture: ComponentFixture<CookieInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CookieInformationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CookieInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
