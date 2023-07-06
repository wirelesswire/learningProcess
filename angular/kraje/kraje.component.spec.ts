import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KrajeComponent } from './kraje.component';

describe('KrajeComponent', () => {
  let component: KrajeComponent;
  let fixture: ComponentFixture<KrajeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KrajeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KrajeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
