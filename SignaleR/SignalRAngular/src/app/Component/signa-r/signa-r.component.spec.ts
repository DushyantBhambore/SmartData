import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignaRComponent } from './signa-r.component';

describe('SignaRComponent', () => {
  let component: SignaRComponent;
  let fixture: ComponentFixture<SignaRComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SignaRComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SignaRComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
