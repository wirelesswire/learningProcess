import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WalutaComponent } from './waluta.component';

describe('WalutaComponent', () => {
  let component: WalutaComponent;
  let fixture: ComponentFixture<WalutaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WalutaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WalutaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
