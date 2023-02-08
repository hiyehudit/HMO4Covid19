import { Component } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular';

  /**
   *
   */
  constructor(private appService: AppService) {


  }


  ngOnInit() {
    this.appService.getClients().subscribe(
      response => {
        console.log(response);

      },
      errror => {
        console.log("check why");

      }
    );


  }
}
