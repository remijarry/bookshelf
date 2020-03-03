import { Component, OnInit, AfterContentInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../_models/books.model';
import { GoogleBookService } from '../_services/googleBook.service';
import { AuthService } from '../_services/auth.service';
import { BookshelfService } from '../_services/bookshelf.service';
import { Bookshelf } from '../_models/bookshelf.model';
import { AlertifyService } from '../_services/alertify.service';
import { BookService } from '../_services/book.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  book: Book;
  bookDescriptionFirstSentence;
  isCollapsed = true;
  isLoggedIn: boolean;
  userBookshelves: Bookshelf[];

  constructor(
    private route: ActivatedRoute,
    private googleBookService: GoogleBookService,
    private authService: AuthService,
    private bookshelfService: BookshelfService,
    private bookService: BookService,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {
    this.isLoggedIn = this.authService.loggedIn();
    if (this.isLoggedIn) {
      this.bookshelfService
        .getBookshelves()
        .subscribe(next => (this.userBookshelves = next));
    }
    this.getBook();
  }

  getBook() {
    const bookId = this.route.snapshot.paramMap.get('id').substr(1);
    this.googleBookService.getById(bookId).subscribe(next => {
      this.book = next;
      this.bookDescriptionFirstSentence = this.book.description.substr(
        0,
        this.book.description.indexOf('.') + 1
      );
    });
  }

  addbook(book: Book, bookshelfId: number) {
    if (this.isLoggedIn) {
      this.bookService.addBook(book, bookshelfId).subscribe(
        () => {
          this.alertifyService.success('Book successfuly added');
        },
        error => {
          this.alertifyService.error('An error occured');
        }
      );
    }
  }
}
