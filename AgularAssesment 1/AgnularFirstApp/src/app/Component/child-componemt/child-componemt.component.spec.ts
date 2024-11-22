import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildComponemtComponent } from './child-componemt.component';

describe('ChildComponemtComponent', () => {
  let component: ChildComponemtComponent;
  let fixture: ComponentFixture<ChildComponemtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildComponemtComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChildComponemtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
