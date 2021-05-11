import { Component, OnInit } from '@angular/core';
import { Member } from '../Member';
import { MemberService } from '../member.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  members: Member[] | undefined;

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
    this.memberService.getMembers()
      .subscribe(x => { this.members = x });
  }
}
