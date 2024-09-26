import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomepageInfoComponent } from './homepage-info.component';

describe('HomepageInfoComponent', () => {
  let component: HomepageInfoComponent;
  let fixture: ComponentFixture<HomepageInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomepageInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HomepageInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
