import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../User';
import { map } from 'rxjs/operators';
import { FormGroup } from '@angular/forms';


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

  register(registerUser) {
    debugger;
    return this.httpClient.post(this.baseUrl + '/register', registerUser);
  }

  setCurrentUser(user: User) {
    this.currentUser = user;
  }

  // getCurrentUser(): User {
  //   if (this.currentUser) {
  //     return this.currentUser;
  //   }
  // }

  logout() {
    localStorage.removeItem('user');
    this.currentUser = undefined;
  }
}
