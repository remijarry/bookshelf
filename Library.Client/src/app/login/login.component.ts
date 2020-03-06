import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(
    private router: Router,
    private authService: AuthService,
    private alertifyService: AlertifyService
  ) {}

  ngOnInit() {

  }

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        const userName = this.authService.decodedToken.unique_name;
        this.router.navigate(['/home']);
      },
      error => {
        this.alertifyService.error(error);
      }
    );
  }
}
