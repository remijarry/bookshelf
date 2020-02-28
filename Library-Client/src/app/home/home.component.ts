import { Component, OnInit, AfterContentInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterContentInit {
  registerMode: boolean;

  constructor(
    private alertifyService: AlertifyService,
    private authService: AuthService
  ) {}

  ngOnInit() {}

  ngAfterContentInit() {
    const userName = this.authService.decodedToken.unique_name;
    this.alertifyService.success(`Welcome back ${userName}`);
  }
}
