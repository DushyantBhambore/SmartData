import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PateintComponent } from './pateint.component';

describe('PateintComponent', () => {
  let component: PateintComponent;
  let fixture: ComponentFixture<PateintComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PateintComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PateintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
