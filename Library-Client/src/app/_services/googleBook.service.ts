import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Book } from '../_models/books.model';

@Injectable({
  providedIn: 'root'
})
export class GoogleBookService {
  private apiKey = 'AIzaSyDBLNSDsbrYXRMJRxmgAr7KC0J8ettWoy4';
  private baseUrl = 'https://www.googleapis.com/books/v1/volumes?q=';

  constructor(private http: HttpClient) {}

  searchBooks(search: string) {
    const encodedURI = encodeURI(
      `${this.baseUrl}"${search}"&key=${this.apiKey}&maxResults=12`
    );

    return this.http.get(encodedURI).pipe(
      map((response: any) => {
        return response.items.map(item => {
          const book = new Book();
          book.googleBookId = item.id;
          book.title = item.volumeInfo.title;
          book.authors = item.volumeInfo.authors;
          book.publisher = item.volumeInfo.publisher;
          // book.publishedDate = item.volumeInfo.publishedDate;
          // console.log(item);
          book.pageCount = item.volumeInfo.pageCount;
          book.categories = item.volumeInfo.categories;
          book.description = item.volumeInfo.description;
          if (
            'imageLinks' in item.volumeInfo &&
            'thumbnail' in item.volumeInfo.imageLinks
          ) {
            book.imageLink = item.volumeInfo.imageLinks.thumbnail;
          } else {
            book.imageLink = '';
          }
          return book;
        });
      })
    );
  }

  getById(bookId: string) {
    const url = encodeURI(
      `https://www.googleapis.com/books/v1/volumes/${bookId}?key=${this.apiKey}`
    );
    return this.http.get(url).pipe(
      map((response: any) => {
        // console.log('hi there', response);
        const book = new Book();
        book.googleBookId = response.id;
        book.title = response.volumeInfo.title;
        book.authors = response.volumeInfo.authors;
        book.publisher = response.volumeInfo.publisher;
        // book.publishedDate = item.volumeInfo.publishedDate;
        book.pageCount = response.volumeInfo.pageCount;
        book.categories = response.volumeInfo.categories;
        book.description = response.volumeInfo.description;
        if (
          'imageLinks' in response.volumeInfo &&
          'thumbnail' in response.volumeInfo.imageLinks
        ) {
          book.imageLink = response.volumeInfo.imageLinks.thumbnail;
        } else {
          book.imageLink = '';
        }
        return book;
      })
    );
  }
}
