import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearCiudadanoComponent } from './crear-ciudadano.component';

describe('CrearCiudadanoComponent', () => {
  let component: CrearCiudadanoComponent;
  let fixture: ComponentFixture<CrearCiudadanoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CrearCiudadanoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearCiudadanoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
