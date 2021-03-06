import { Component, OnInit } from '@angular/core';
import { AccountService } from './services/account.service';
import { User } from './User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'MyFirstApi-Angular';
  constructor(private AccountService: AccountService) { }

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user') || '{}');
    this.AccountService.setCurrentUser(user);
  }
}