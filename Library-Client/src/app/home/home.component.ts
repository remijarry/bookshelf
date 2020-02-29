import { Component, OnInit, AfterContentInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { GoogleBookService } from '../_services/googleBook.service';
import { Book } from '../_models/books.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  books: Book[];
  constructor(private googleBookService: GoogleBookService) {}

  ngOnInit() {}

  searchBooks(f) {
    this.googleBookService
      .searchBooks(f.value.inputSearch)
      .subscribe((books: Book[]) => {
        this.books = books;
      });
  }
}
