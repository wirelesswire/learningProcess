import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RezystancjaComponent } from './rezystancja.component';

describe('RezystancjaComponent', () => {
  let component: RezystancjaComponent;
  let fixture: ComponentFixture<RezystancjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RezystancjaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RezystancjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
