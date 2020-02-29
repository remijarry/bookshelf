import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

// todo: move imports from ngx to into its own module
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'ngx-bootstrap';
import { CollapseModule } from 'ngx-bootstrap/collapse';

import { AppComponent } from './app.component';
import { BookComponent } from './Book/Book.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { LoginComponent } from './login/login.component';
import { appRoutes } from './routes';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BookDetailsComponent } from './book-details/book-details.component';

@NgModule({
   declarations: [
      AppComponent,
      BookComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      LoginComponent,
      DashboardComponent,
      BookDetailsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      BsDropdownModule.forRoot(),
      CarouselModule.forRoot(),
      CollapseModule.forRoot(),
      BrowserAnimationsModule,
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}
