import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { ShotDTO } from '../classes/shot';
import { Shot4ClientDTO } from '../classes/shot4client';

@Component({
  selector: 'app-update-shot',
  templateUrl:'./update-shot.component.html',
  styleUrls: ['./update-shot.component.css']
})
export class UpdateShotComponent implements OnInit {
  shots:Array<ShotDTO>=new Array<ShotDTO>();
  model = new Shot4ClientDTO();
  shot4:Shot4ClientDTO |undefined;
  isAddShot=true;
  submitted = false;
  f:any;
  selected=new ShotDTO();
  constructor(public _Activatedroute:ActivatedRoute,private http:ApiService) { }

  ngOnInit(): void {
    this._Activatedroute.paramMap.subscribe((params) => {
      this.model.Id_shot4Client= parseInt(params.getAll("id")[0]);
      this.model.tz= params.getAll("tz")[0];
      console.log('object :>> ',params);
      console.log('object44 :>> ',this.model.tz,this.model.Id_shot4Client);
    });
    this.http.getShots().subscribe((s)=>{
      this.shots=s
    })
  }
  onSubmit() { this.submitted = true; }
  clearShot4() {
  console.log('this.newClient :>> ', this.model);
  this.shot4 = new Shot4ClientDTO();
  }
 getShots(){
  this.http.getShots().subscribe((s)=>{
    this.shots=s;
  })
 }
  updateShot4(){
    console.log('s :>> ', this.model);
    
    //update client
    this.http.UpdateShot4Client(this.model).subscribe((s)=>{
      console.log('s :>> ', s);
      this.submitted = false;

    })
 
    }
   
    
      onOptionsSelected() {
        console.log(this.selected); 
        this.f = this.shots.filter(t=>t.menufactorer ==this.selected.menufactorer);
        this.model.codeShot=this.selected.codeShot;
      }


}
