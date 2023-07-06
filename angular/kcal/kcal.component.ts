import { Component, OnInit } from '@angular/core';
import {FormsModule} from '@angular/forms';
@Component({
  selector: 'app-kcal',
  templateUrl: './kcal.component.html',
  styleUrls: ['./kcal.component.scss']
})
export class KcalComponent implements OnInit {
  plec:string="kobieta";
  aktywnosc:string="wysoka";
  dodane:jedzenie[]=[]
  jedzenia:jedzenie[] =[
    {nazwa:"jabłko",ilosc:200,kcal:50},
    {nazwa:"mielone",ilosc:400,kcal:200},
    {nazwa:"chleb",ilosc:1000,kcal:500},
  ]
  kolor = "white"
plci:string[] =[  "kobieta","mezczyzna"]
aktywnoscimozliwe:string[]=[  "niska","umiarkowana","wysoka"]

  // aktywnosci = {
  //   "kobieta":{"niska":[1300,1900],"umiarkowana":[1700,2200],"wysoka":[2200,2600]},
  //   "mezczyzna":{"niska":[1600,2100],"umiarkowana":[1850,2400],"wysoka":[2050,2650]}
  // }
    
  aktywnosci = [
    [[1300,1900],[1700,2200],[2200,2600]],
    [[1600,2100],[1850,2400],[2050,2650]]
]




  constructor() { }

  ngOnInit(): void {
  }
  dodaj(){
    let x = <HTMLSelectElement> document.querySelector("#selecteditem")
    this.dodane.push(this.jedzenia[ x.selectedIndex])
    this.czysiemiesci();
  }
  usun(j:number){
    this.dodane.splice(j,1)
    this.czysiemiesci();
  }

  usunwszystko(){
    this.dodane = [] 
  }
  lacznekcal(){
    let suma =0 
    this.dodane.forEach(el=>{
      suma+= el.kcal
    })
    return suma  
  }
  czysiemiesci(){
    let kcal = this.lacznekcal()
    let min = this.aktywnosci[this.plci.indexOf(this.plec)][this.aktywnoscimozliwe.indexOf( this.aktywnosc)][0]
    let max = this.aktywnosci[this.plci.indexOf(this.plec)][this.aktywnoscimozliwe.indexOf( this.aktywnosc)][1]
    if(kcal >=min && kcal <= max ){
      this.kolor = "green"
      return "jest ok "
    }
    else if( kcal<min){
      this.kolor = "red"
      return "zjedz wiecej "
    }
    else if (kcal >max ){
      this.kolor ="red"
      return "jedz mniej "
    }
    return "cos sie razwaliło nie powiinno tu dojsc "
  }



}
interface jedzenie{
  nazwa:string;
  ilosc:number;
  kcal:number;
}
// enum plci{
//   "kobieta"=0,
//   "mezczyzna"=1
// }
// enum aktywnosc{
//   "niska"=0,
//   "umiarkowana"=1,
//   "wysoka"=2
// }
