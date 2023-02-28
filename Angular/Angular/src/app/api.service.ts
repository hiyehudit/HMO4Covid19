import { Injectable } from '@angular/core';
import { HttpClient,HttpParams } from '@angular/common/http';
import { PersonDTO } from './classes/PersonDTO';
import { Observable, Observer } from 'rxjs';
import { AdressDTO } from './classes/fff';
import { ShotDTO } from './classes/shot';
import { Shot4ClientDTO } from './classes/shot4client';

@Injectable({
  providedIn: 'root'
})

export class ApiService {
  url:string="https://localhost:44301/api/Default3/"
  constructor(private http:HttpClient) { }
//clients
   public getClient(tz:string):Observable<PersonDTO>{
    console.log('tz :>> ', tz);
    var paramsTz = new HttpParams({
      fromObject: {
      tz:tz,
      }
      });
     
    return this.http.get<PersonDTO>(this.url+"getClient",{params:paramsTz});
  }
  public getClients():Observable<Array<PersonDTO>>
  {
    return this.http.get<Array<PersonDTO>>(this.url+"getClients");
  }
  public AddClient(client:PersonDTO){
    return this.http.post( this.url+"AddClient",client);
  }
  public UpdateClient(c:PersonDTO){
    var paramsTz = new HttpParams({
      // fromObject: {
      //   tz:c.tz,
      //   firstName :c.firstName,
      //   lastName:c.lastName
      //   postalCode :c.postalCode,
      //   birthDate:c.birthDate,
      //   telephone:c.telephone,
      //   selphone:c.selphone
      //   beIllDate:Date=new Date()
      //   beHealthDate:Date=new Date()
      // }
      });
    return this.http.post(this.url+"UpdateClient",c);
  }
  public DeleteClient(tz:string){
   var paramsTz = new HttpParams({
     fromObject: {
     tz:tz,
     }
     });
   return this.http.get(this.url+"DeleteClient",{params:paramsTz});
 }
 //adress
 public getAdress(tz:string):Observable<AdressDTO>{
  console.log('tz :>> ', tz);
  var paramsTz = new HttpParams({
    fromObject: {
    tz:tz,
    }
    });
   
  return this.http.get<AdressDTO>(this.url+"getAdress",{params:paramsTz});
}
public AddAdress(a:AdressDTO){
  return this.http.post( this.url+"AddAdress",a);
}
public UpdateAdress(a:AdressDTO){
  return this.http.post( this.url+"UpdateAdress",a);
}
 //shot
 public GetManufactorersByTz(codeShot:number):Observable<string>{
  var paramsTz = new HttpParams({
    fromObject: {
      codeShot:codeShot,
    }
    });
    return this.http.get<string>(this.url+" GetManufactorersByTz",{params:paramsTz});
  }
  public getShots():Observable<Array<ShotDTO>>
  {
    return this.http.get<Array<ShotDTO>>(this.url+"getShots");
  }
//shot4
public GetShots4ByTz(tz:string):Observable<Array<Shot4ClientDTO>>
{
  var paramsTz = new HttpParams({
    fromObject: {
      tz:tz,
    }
    });
  return this.http.get<Array<Shot4ClientDTO>>(this.url+"GetShots4ByTz",{params:paramsTz});
}
public AddShot4(s:Shot4ClientDTO){
  return this.http.post( this.url+"AddShot4",s);
}
public UpdateShot4Client(s:Shot4ClientDTO){
  return this.http.post( this.url+"UpdateShot4Client",s);
}
public DeleteShot4(tz:string){
  var paramsTz = new HttpParams({
    fromObject: {
    tz:tz,
    }
    });
  return this.http.get(this.url+"DeleteShot4",{params:paramsTz});
}
}
