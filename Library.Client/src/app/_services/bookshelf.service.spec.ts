/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BookshelfService } from './bookshelf.service';

describe('Service: Bookshelf', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookshelfService]
    });
  });

  it('should ...', inject([BookshelfService], (service: BookshelfService) => {
    expect(service).toBeTruthy();
  }));
});
