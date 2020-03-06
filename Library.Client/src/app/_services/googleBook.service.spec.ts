/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GoogleBookService } from './googleBook.service';

describe('Service: GoogleBook', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GoogleBookService]
    });
  });

  it('should ...', inject([GoogleBookService], (service: GoogleBookService) => {
    expect(service).toBeTruthy();
  }));
});
