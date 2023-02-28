import { Component, OnInit } from '@angular/core';
import { PersonDTO } from '../classes/PersonDTO';
import { AppService } from '../app.service';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { AdressDTO } from '../classes/fff';
import { Shot4Shot } from '../classes/shot4-shot';
import { Shot4ClientDTO } from '../classes/shot4client';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  isAddUser:boolean|undefined;
  product_id :string="";
  newClient=new PersonDTO();
  shots4=new Array<Shot4ClientDTO>();
  model = new PersonDTO();
  adress=new AdressDTO();
  submitted = false;
  constructor(public ser:AppService,private http:ApiService,private _Activatedroute:ActivatedRoute) { }
  ngOnInit(): void {
    this._Activatedroute.paramMap.subscribe((params) => {
      this.product_id = params.get('tz')!;
      console.log(this.product_id,params);
      this.isAddUser=this.product_id!=''?false:true;
      console.log('this.isAddUser :>> ',this.product_id);
      //אם צריך עדכון
  if(!this.isAddUser){
    //client
    //adress
    this.http.getAdress(this.product_id).subscribe((p)=>{
     this.adress=p;
    })
   this.http.getClient(this.product_id).subscribe((x:PersonDTO) => {
    console.log(x);
       this.model=x;
    });
  //shot4
  if(this.product_id){
  this.http.GetShots4ByTz(this.product_id).subscribe((p)=>{
    this.shots4=p;
   })
  }
}
     
    });
    
  }
 
onSubmit() { this.submitted = true; }
clearClient() {
console.log('this.newClient :>> ', this.model);
this.newClient = new PersonDTO();
}
send(){
  this.submitted = false;
  if(this.isAddUser){
    //add Cient
    this.http.AddClient(this.model).subscribe((x:any) => {
      console.log(x);
      });
    //add adress
    this.adress.tz=this.model.tz;
    this.http.AddAdress(this.adress).subscribe((x:any) => {
      console.log(x);
      });
    //add shots
    this.shots4.forEach((s)=>{
  this.http.AddShot4(s).subscribe((x:any) => {
    console.log(x);
  }); 
     })
  }
  else{
   
     //update client
    this.http.UpdateClient(this.model).subscribe((x:any) => {
      console.log(x);
         this.model=x;
      });
         //update adress
         console.log("coming");
    this.http.UpdateAdress(this.adress).subscribe((s)=>{
      console.log('this.adress :>> ', this.adress);
    })
    this.http.UpdateClient(this.model).subscribe((x:any) => {
      console.log(x);
      });
   this.shots4.forEach((s)=>{
        this.http.UpdateShot4Client(s).subscribe((x:any) => {
          console.log(x);
        }); 
      })
  }
}
}
