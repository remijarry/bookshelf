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
  userId: number;
  baseUrl = 'http://localhost:5000/api/bookshelves/'; // todo: global variable
  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {
    this.userId = parseInt(this.authService.decodedToken.nameid, 10);
  }

  addBook(book: Book, bookshelfId: number) {
    book.userId = this.userId;
    book.bookshelfId = bookshelfId;
    return this.httpClient.post(this.baseUrl + 'add', book);
  }

  getBookshelves() {
    return this.httpClient.get(`${this.baseUrl}${this.userId}`).pipe(
      map((response: Bookshelf[]) => {
        return response;
      })
    );
  }
}
