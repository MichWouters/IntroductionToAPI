import { Component, OnInit } from '@angular/core';
import { Member } from '../Member';
import { MemberService } from '../services/member.service';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  members: Member[] | undefined // Avoid having to initialize this with empty properties

  constructor(private memberService: MemberService) { }

  ngOnInit(): void {
    this.loadMembers();
  }
  loadMembers() {
    this.memberService.getMembers()
      .subscribe(members => {this.members = members});
  }

}
