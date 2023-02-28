import { BehaviorSubject, Observable } from "rxjs";
import { HttpClient } from '@angular/common/http'
import { Injectable } from "@angular/core";
import { PersonDTO } from "./classes/PersonDTO";
import { AdressDTO } from "./classes/fff";


@Injectable({
    providedIn: 'root'
})

export class AppService {
    constructor(private httpClient: HttpClient) {

    }
    // public clientList:Array<ClientDTO>=new Array<ClientDTO>;

    url:string="https://localhost:44301/home/"
    private title = new BehaviorSubject<string>("");
    currentTitle = this.title.asObservable();

    setTitle(txt: string){
        this.title.next(txt);
    }
     public getClients():Observable<Array<PersonDTO>>{
     return this.httpClient.get<Array<PersonDTO>>(this.url+'GetClients');
    }

    public addClient(c:PersonDTO): Observable<string>
    {
      console.log('addClient-service:>>');
      return this.httpClient.post<string>(this.url+'AddClient',c);
    }
    public GetShotsByTz(tz:string): Observable<string>
    {
      console.log('GetShotsByTz-service:>> ');
      return this.httpClient.post<string>(this.url+'GetShotsByTz',tz)
    }
    public AddShot(f:AdressDTO): Observable<string>
    {
      console.log('AddShot-service:>> ');
       return this.httpClient.post<string>(this.url+'/AddShot',f);
    }
  // public getAll():Observable<Array<Client>>{
  //     return this.httpClient.get<Array<Client>>('https://localhost:44301/api/home1/getAll')
  //       }
  public getAll():Observable<Array<string>>{
      return this.httpClient.get<Array<string>>('http://http://www.w3.org/localhost:44301/api/values')
        }
}

