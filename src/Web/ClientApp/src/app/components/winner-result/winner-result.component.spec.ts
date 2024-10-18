import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WinnerResultComponent } from './winner-result.component';

describe('WinnerResultComponent', () => {
  let component: WinnerResultComponent;
  let fixture: ComponentFixture<WinnerResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WinnerResultComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WinnerResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
