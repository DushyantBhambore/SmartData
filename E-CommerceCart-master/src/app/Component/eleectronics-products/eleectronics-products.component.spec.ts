import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EleectronicsProductsComponent } from './eleectronics-products.component';

describe('EleectronicsProductsComponent', () => {
  let component: EleectronicsProductsComponent;
  let fixture: ComponentFixture<EleectronicsProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EleectronicsProductsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EleectronicsProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
