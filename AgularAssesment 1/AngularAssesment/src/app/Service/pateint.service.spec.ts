import { TestBed } from '@angular/core/testing';

import { PateintService } from './pateint.service';

describe('PateintService', () => {
  let service: PateintService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PateintService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
