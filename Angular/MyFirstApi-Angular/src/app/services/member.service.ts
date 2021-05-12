import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Member } from '../Member';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = 'https://localhost:44388/api/users/members';

  constructor(private httpClient: HttpClient) { }

  getMembers() {
    return this.httpClient.get<Member[]>(this.baseUrl);
  }

  getMember(id: number) {
    return this.httpClient.get<Member>(`this.baseUrl/${id}`);
  }
}