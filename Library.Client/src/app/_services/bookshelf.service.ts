import { Injectable } from '@angular/core';
import { Book } from '../_models/books.model';
import { HttpClient } from '@angular/common/http';
import { Bookshelf } from '../_models/bookshelf.model';
import { map } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class BookshelfService {
  baseUrl = 'http://localhost:5000/api/bookshelves/'; // todo: global variable
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {}


  getBookshelves() {
    const userId = parseInt(this.authService.decodedToken.nameid, 10);
    return this.httpClient.get(`${this.baseUrl}${userId}`).pipe(
      map((response: Bookshelf[]) => {
        return response;
      })
    );
  }
}
