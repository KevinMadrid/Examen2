import { TestBed } from '@angular/core/testing';

import { CiudadanosService } from './ciudadanos.service';

describe('CiudadanosService', () => {
  let service: CiudadanosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CiudadanosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
