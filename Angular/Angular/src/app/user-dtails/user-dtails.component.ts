import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AdressDTO } from '../classes/fff';
import { Shot4ClientDTO } from '../classes/shot4client';
import { Client } from '../classes/uset';
import { ApiService } from '../api.service';
import { PersonDTO } from '../classes/PersonDTO';
import { ShotDTO } from '../classes/shot';
import { Shot4Shot } from '../classes/shot4-shot';


@Component({
  selector: 'app-user-dtails',
  templateUrl: './user-dtails.component.html',
  styleUrls: ['./user-dtails.component.css']
})
export class UserDtailsComponent implements OnInit {
hiddenForm=false;

user=new PersonDTO();
product_id!:string;
adrees=new AdressDTO();
shots4 :Array<Shot4ClientDTO>|undefined;
f :Array<Shot4Shot>|undefined;
k:Array<Shot4ClientDTO>|undefined;
router: any;
shots=new Array<ShotDTO>();
constructor(private _Activatedroute:ActivatedRoute,public http:ApiService){}
  ngOnInit(): void {
    this._Activatedroute.paramMap.subscribe((params) => {
      this.product_id = params.get('id')!;
    });
  this.http.getClient(this.product_id).subscribe((x:PersonDTO) => {
    console.log(x);
       this.user=x;
    });
  this.http.getAdress(this.product_id).subscribe((x:AdressDTO) => {
    console.log(x);
       this.adrees=x;
        this.adrees.tz=this.product_id;
   
    });
  this.http.GetShots4ByTz(this.product_id).subscribe((x:Array<Shot4ClientDTO>|undefined) => {
    this.k=x;
    console.log(this.k,x);
    });
//מכניס כל חיסוןלפצינט ביחד עם שם החיסון לרשימה
    this.k?.forEach((s)=>{
    this.http.GetManufactorersByTz(s.codeShot).subscribe((x:string) => {
     var v=new Shot4Shot();
          v=<Shot4Shot>s;
          v.menufactorer=x;
          this.f?.push(v);
      // let sho=new ShotDTO()
      // sho.codeShot=s.codeShot;
      // sho.menufactorer=x;
      //    this.shots.push(sho);
      });
  }

  )
  console.log('f :>> ', this.f);
    this.hiddenForm=this.user==undefined?false:true;
    console.log('this._Activatedroute :>> ', this.product_id)
  }
  deleteShot4(item:Shot4ClientDTO){
    this.http.DeleteShot4(item.tz).subscribe((s)=>{
      console.log('s :>> ', s);
    })
  }
}
