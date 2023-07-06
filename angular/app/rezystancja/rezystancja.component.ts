import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-rezystancja',
  templateUrl: './rezystancja.component.html',
  styleUrls: ['./rezystancja.component.css']
})
export class RezystancjaComponent implements OnInit {

  rezystancje:number[]  = [] 
  szeregowo:boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  dodaj(){
    let x = <HTMLInputElement>document.querySelector("#rezy");
    this.rezystancje.push(Number(x.value))
  }  
  usun(index:number){
    this.rezystancje.splice(index,1)
  }
  usunwszystko(){
    this.rezystancje=[]
  }
  zmienradio(x:boolean){
    this.szeregowo = x
  }
  wynikObliczen(){
   if(this.rezystancje.length == 0 ){
     return " podaj rezystancje "
   }
   let rezystancja = 0 ;
   if(this.szeregowo){
    this.rezystancje.forEach(element=>{
      rezystancja+=element
    })
   }
   else{
    let sumapod = 0 
    this.rezystancje.forEach(ele=>{
      sumapod+=1/ele
    })
    rezystancja = 1/sumapod

   }
   return rezystancja

  }
}
