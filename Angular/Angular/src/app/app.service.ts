import { observable } from "rxjs";
import { HttpClient } from '@angular/common/http'
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root'
})
export class AppService {

    /**
     *
     */
    constructor(private httpClient: HttpClient) {

    }

    public getClients() {
      return      this.httpClient.get('https://localhost:44301/home/GetClients');
    }

}