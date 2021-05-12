import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../User';
import { map } from 'rxjs/operators';
import { Register } from '../Register';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:44388/api/account';
  currentUser?: User;

  constructor(private httpClient: HttpClient) { }

  login(model: any): Observable<any> {
    let url = `${this.baseUrl}/login`;

    return this.httpClient.post(url, model).pipe(
      map((response: any) => {
        const user: User = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.setCurrentUser(user);
        }
      })
    );
  }

  register(model: Register): Observable<any> {
    let url = 'https://localhost:44388/api/Account/Register';
    return this.httpClient.post(url, model).pipe(
      map((response: any) => {
        const user: User = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.setCurrentUser(user);
        }
      })
    );
  }

  setCurrentUser(user: User) {
    this.currentUser = user;
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser = undefined;
  }
}
