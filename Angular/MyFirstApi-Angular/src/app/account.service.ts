import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:44388/api/account';

  constructor(private httpClient: HttpClient) { }

  login(model: any): Observable<any>{
    let url = `${this.baseUrl}/login`;

    return this.httpClient.post(url, model);
  }
}
