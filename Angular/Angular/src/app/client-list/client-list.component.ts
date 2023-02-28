import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { PersonDTO } from '../classes/PersonDTO';
// import { Client } from '../classes/client';
//import { ClientDTO } from '../classes/PersonDTO';
import { Routes, Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../api.service';
import { Shot4ClientDTO } from '../classes/shot4client';

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html',
  styleUrls: ['./client-list.component.css']
})
export class ClientListComponent implements OnInit {

//  public clients1=any[];
constructor(public http:ApiService, public appService:AppService,public router:Router,public httpClient: HttpClient){ }
clients:Array<PersonDTO>|undefined;
user:PersonDTO =new PersonDTO();
isDtails=true;
ngOnInit(): void {
  // this.http.getClient("oo").subscribe((x:any) => {
  //   console.log(x);
  //   });
 this.getClients();

  this.user.firstName="חיה";
  this.user.lastName="כהן"; 
  this.user.tz="010101"
  this.user.telephone="00000" 

    // this.appService.getAll().subscribe(
    //   response => {
    //     console.log(response,"res")
    //     //  this.clients=response;

    //   },
    //   errror => {
    //     console.log("check why");

    //   }
    // );
  }
  redirect(item:PersonDTO){
    this.router.navigateByUrl('userDtails/'+item);
}
showDtails(){
  this.appService.setTitle("Your title or data");
}
deleteClient(c:PersonDTO){
this.http.DeleteClient(c.tz).subscribe((x:any) => {
    console.log(x);
    });
this.getClients();
}
getClients(){
  this.http.getClients().subscribe((x:Array<PersonDTO>|undefined) => {
    this.clients=x;
    console.log(x);
    });

}
back(): void {
 

}
}
