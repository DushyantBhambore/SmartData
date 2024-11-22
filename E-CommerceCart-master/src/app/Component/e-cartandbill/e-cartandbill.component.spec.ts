import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ECartandbillComponent } from './e-cartandbill.component';

describe('ECartandbillComponent', () => {
  let component: ECartandbillComponent;
  let fixture: ComponentFixture<ECartandbillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ECartandbillComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ECartandbillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
