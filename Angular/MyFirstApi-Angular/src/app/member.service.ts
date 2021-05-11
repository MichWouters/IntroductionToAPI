import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Member } from './Member';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = 'https://localhost:44388/api/users';
  
  httpOptions = {
    headers: new HttpHeaders({
      Authorization: `Bearer ${JSON.parse(localStorage.getItem('user')|| '{}').token}`
    })
  };
  constructor(private httpClient: HttpClient) { }

  getMembers(){
    return this.httpClient.get<Member[]>(`${this.baseUrl}/members`, this.httpOptions);
  };

  getMember(id: number){
    return this.httpClient.get<Member[]>(`${this.baseUrl}/member{}`, this.httpOptions);
  };
}
