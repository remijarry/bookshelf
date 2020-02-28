import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guard/auth.guard';
import { BookComponent } from './Book/Book.component';

export const appRoutes: Routes = [
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
        { path: 'home', component: HomeComponent },
        { path: 'add-book', component: BookComponent },

      ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  { path: '**', redirectTo: 'HomeComponent', pathMatch: 'full' }
];
