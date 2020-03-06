import { Component, OnInit } from '@angular/core';
import { BookService } from '../_services/book.service';
import { Book } from '../_models/books.model';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  readingBooks: Book[];
  toReadBooks: Book[];
  userId: number;

  constructor(
    private bookService: BookService,
    private authService: AuthService
  ) {}

  ngOnInit() {
    this.userId = parseInt(this.authService.decodedToken.nameid, 10);
    this.bookService
      .getReadingBooks()
      .subscribe(next => (this.readingBooks = next));
    this.bookService
      .getToReadBooks()
      .subscribe(next => (this.toReadBooks = next));
  }
}
