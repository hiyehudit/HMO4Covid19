import { Component } from '@angular/core';
import { AppService } from './app.service';
import { AccountService } from './_services/account.service';
import { UserDTO } from './_models/user';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user?: UserDTO | null;
  title = 'Angular';
  clients=[];
  constructor(private accountService: AccountService,private appService: AppService) {
    this.accountService.user.subscribe(x => this.user = x);

  }
  ngOnInit() { 
  }
  logout() {
    this.accountService.logout();
}

}
