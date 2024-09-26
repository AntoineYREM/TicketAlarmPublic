import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BestShowsComponent } from './best-shows.component';

describe('BestShowsComponent', () => {
  let component: BestShowsComponent;
  let fixture: ComponentFixture<BestShowsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BestShowsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BestShowsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
