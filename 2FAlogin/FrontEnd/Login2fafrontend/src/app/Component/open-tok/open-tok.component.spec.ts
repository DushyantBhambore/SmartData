import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpenTokComponent } from './open-tok.component';

describe('OpenTokComponent', () => {
  let component: OpenTokComponent;
  let fixture: ComponentFixture<OpenTokComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OpenTokComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpenTokComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
