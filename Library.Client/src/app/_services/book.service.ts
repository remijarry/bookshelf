import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../_models/books.model';
import { AuthService } from './auth.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  baseUrl = 'http://localhost:5000/api/bookshelves'; // todo: global variable
  userId: number;

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {
    this.userId = parseInt(this.authService.decodedToken.nameid, 10);
  }

  getReadingBooks() {
    return this.httpClient.get(`${this.baseUrl}/${this.userId}/books/reading`).pipe(
      map((response: Book[]) => {
        return response;
      })
    );
  }

  getToReadBooks() {
    return this.httpClient.get(`${this.baseUrl}/${this.userId}/books/toread`).pipe(
      map((response: Book[]) => {
        return response;
      })
    );
  }

  addBook(book: Book, bookshelfId: number) {
    const userId = parseInt(this.authService.decodedToken.nameid, 10);
    book.userId = userId;
    book.bookshelfId = bookshelfId;
    return this.httpClient.post(`${this.baseUrl}/${userId}/books/add`, book);
  }
}
