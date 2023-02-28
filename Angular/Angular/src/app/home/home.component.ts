import { Component } from '@angular/core';

import { UserDTO } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    user: UserDTO | null;

    constructor(private accountService: AccountService) {
        this.user = this.accountService.userValue;
    }
}