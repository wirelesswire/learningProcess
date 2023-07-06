import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MacierzeComponent } from './macierze.component';

describe('MacierzeComponent', () => {
  let component: MacierzeComponent;
  let fixture: ComponentFixture<MacierzeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MacierzeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MacierzeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
