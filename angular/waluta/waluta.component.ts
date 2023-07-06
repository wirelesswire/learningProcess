import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-waluta',
  templateUrl: './waluta.component.html',
  styleUrls: ['./waluta.component.css']
})
export class WalutaComponent implements OnInit {
  operacje:operacja[]=[]
  koszty:operacja[]=[]
  przychody:operacja[]=[]
  constructor() { }
  ngOnInit(): void {
  }
  dodaj(typ:string){
    let iloscWaluty;
    let kurs ;
    if(typ =="przychod"){
      iloscWaluty=<HTMLInputElement>document.querySelector("#obcaprzychody")
      kurs = <HTMLInputElement>document.querySelector("#kursprzychody")
    }
    else if(typ=="koszt"){
      iloscWaluty=<HTMLInputElement>document.querySelector("#obcakoszty")
      kurs = <HTMLInputElement>document.querySelector("#kurskoszty")
    }
    if(iloscWaluty != null && kurs !=null){
      let tmp:operacja = {kwota:Number( iloscWaluty.value),kurs: Number(kurs.value),wartosc:Number( iloscWaluty.value)*Number(kurs.value)}
      if(typ =="przychod"){
        this.przychody.push(tmp)
      }
      else if(typ=="koszt"){
       this.koszty.push(tmp)
      }
      this.operacje.push(tmp);    
    }
  }
  zaokraglij(co:number){
    return Math.round(co);
  }
  usun(nazwa:string,index:number){
    if(nazwa =="przychody"){
      this.przychody.splice(index,1)
    }
    else if(nazwa=="koszty"){
      this.koszty.splice(index,1)
    }
  }
  suma(nazwa:string){
    let suma=0
    if(nazwa =="przychody"){
      this.przychody.forEach(element=>{
        suma+=element.wartosc
      })
    }
    else if(nazwa=="koszty"){
      this.koszty.forEach(element=>{
        suma+=element.wartosc
      })
    }
    return suma 
  }
  
}
interface operacja {
kwota:number,
kurs:number,
wartosc:number,
}