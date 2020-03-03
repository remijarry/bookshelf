import { Component, OnInit } from '@angular/core';
import { GoogleBookService } from '../_services/googleBook.service';
import { Book } from '../_models/books.model';
import { BookService } from '../_services/book.service';
import { AlertifyService } from '../_services/alertify.service';
import { Bookshelf } from '../_models/bookshelf.model';
import { AuthService } from '../_services/auth.service';
import { BookshelfService } from '../_services/bookshelf.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {
  constructor(
    private googleBookService: GoogleBookService,
    private bookService: BookService,
    private alertifyService: AlertifyService,
    private authService: AuthService,
    private bookshelfService: BookshelfService
  ) {}

  books: Book[];
  userBookshelves: Bookshelf[];

  ngOnInit() {
    const userId = this.authService.decodedToken.nameid;
    this.bookshelfService
      .getBookshelves()
      .subscribe(next => (this.userBookshelves = next));
  }

  addBook(book: Book, bookshelfId: string) {
    this.bookService.addBook(book, parseInt(bookshelfId)).subscribe(
      () => {
        this.alertifyService.success('book successfully added');
      },
      error => {
        this.alertifyService.error('an error occured, please try again later');
      }
    );
  }
}
