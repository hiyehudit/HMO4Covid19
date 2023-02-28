import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { range } from 'rxjs';
import { ApiService } from '../api.service';
import { ShotDTO } from '../classes/shot';
import { Shot4ClientDTO } from '../classes/shot4client';

@Component({
  selector: 'app-add-update-shot',
  templateUrl: './add-update-shot.component.html',
  styleUrls: ['./add-update-shot.component.css']
})
export class AddUpdateShotComponent implements OnInit {
  shots:Array<ShotDTO>=new Array<ShotDTO>();
  shot=new ShotDTO();
  shot4=new Shot4ClientDTO();
  model = new Shot4ClientDTO();
  isAddShot=true;
  f:any;
  submitted = false;
  selected:any;
  constructor(public _Activatedroute:ActivatedRoute,private http:ApiService) {   
  
} 

  ngOnInit(): void {
    
    this._Activatedroute.paramMap.subscribe((params) => {
      // == params.getAll;
      this.model.tz= params.getAll('tz')[0];
      console.log('params[0] :>> ', this.model.tz);
    });
    this.http.getShots().subscribe((s)=>{
      this.shots=s
    })
    // this.shot.codeShot=6;
    // this.shot.menufactorer="fizer";
    this.shots.push(this.shot )
  }
  onSubmit() { this.submitted = true; }
  clearClient() {
  console.log('this.newClient :>> ', this.model);
  this.shot4 = new Shot4ClientDTO();
  }
  addShot4(){
  this.model.codeShot=this.selected;
  this.model.Id_shot4Client =parseInt(this.model.tz+this.model.codeShot+this.model.shotDate.getTime.apply)
  console.log('model :>> ', this.model,this.selected,this.f,this.shot)
  this.http.AddShot4(this.model).subscribe((s)=>{
    console.log('s :>> ', s);
  })
  this.submitted = false;
  }

  onOptionsSelected() {
    console.log(JSON.stringify(this.selected, null, 2)); 
    this.f = this.shots.filter(t=>t.menufactorer ==this.selected.menufactorer);
    this.model.codeShot=this.selected.codeShot;
  }

  
}
