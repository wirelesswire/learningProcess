import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kraje',
  templateUrl: './kraje.component.html',
  styleUrls: ['./kraje.component.css']
})
export class KrajeComponent implements OnInit {

  constructor() { }
  continents = ["azja","europa","ameryka pł","ameryka płd"] 
  selectedcontinent:country[] =[]
  selectedcountry :country|null =null
  countries:country[] = [
    {name:"polska",population:37,continent:"europa",flagpath:"assets/polska.png"},
    {name:"usa",population:300,continent:"ameryka pł",flagpath:"assets/usa.png"},
    {name:"chiny",population:1000,continent:"azja",flagpath:"assets/chiny.png"},
    {name:"indie",population:1380,continent:"azja",flagpath:"assets/indie.png"},
    {name:"rosja",population:1000,continent:"azja",flagpath:"assets/rosja.png"},
    
  
  ]


  countriesincontinent(continent:string){
    let tmp:country[] = [] 
    this.countries.forEach(el=>{
      if(el.continent==continent){
        tmp.push(el)
      }
    })
    return tmp
  }
  countrywithname(name:string){
    let tmp =null 
    this.countries.forEach(el=>{
      if(el.name==name){
        tmp =  el
      }
    })

    return tmp
  }

  
  zmianakontynent(){
    let idx = <HTMLSelectElement>(document.querySelector("#kontynent"))
    this.selectedcontinent = this.countriesincontinent( idx.selectedOptions[0].value)
    // this.zmianakraj()
  }
  zmianakraj(){
    let idx = <HTMLSelectElement>(document.querySelector("#kraj"))
    this.selectedcountry = this.countrywithname( idx.selectedOptions[0].value)
  }
  ngOnInit(): void {
  }
}
interface country{
name:string,
population:number,
continent:string,
flagpath:string
}