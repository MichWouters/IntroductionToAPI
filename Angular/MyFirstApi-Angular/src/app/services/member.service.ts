import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Member } from '../Member';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = 'https://localhost:44388/api/users/members';

  httpOptions = {
    headers: new HttpHeaders({
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('user') || '{}').token}`
    })
  };

  constructor(private httpClient: HttpClient) { }

  getMembers() {
    return this.httpClient.get<Member[]>(this.baseUrl, this.httpOptions);
  }

  getMember(id: number) {
    return this.httpClient.get<Member>(`this.baseUrl/${id}`, this.httpOptions);
  }
}
