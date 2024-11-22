import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EleectronicsdashboardComponent } from './eleectronicsdashboard.component';

describe('EleectronicsdashboardComponent', () => {
  let component: EleectronicsdashboardComponent;
  let fixture: ComponentFixture<EleectronicsdashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EleectronicsdashboardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EleectronicsdashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
