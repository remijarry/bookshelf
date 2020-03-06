import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guard/auth.guard';
import { BookComponent } from './Book/Book.component';
import { BookDetailsComponent } from './book-details/book-details.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'book-details/:id', component: BookDetailsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: '**', redirectTo: '/home', pathMatch: 'full' },

  // {
  //   path: '',
  //   runGuardsAndResolvers: 'always',
  //   canActivate: [AuthGuard],
  //   children: [{ path: 'add-book', component: BookComponent }]
  // },

];
