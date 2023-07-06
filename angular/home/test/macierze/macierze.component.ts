import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-macierze',
  templateUrl: './macierze.component.html',
  styleUrls: ['./macierze.component.scss']
})
export class MacierzeComponent implements OnInit {

  constructor() { }
  rowsx: number = 3
  colsy: number = 3;
  macierz: number[][] = []
  wyznacznikmacierzy=0
  ngOnInit(): void {
    this.zrobmacierz()
  }
  zmiana() {
    let x = <HTMLInputElement>document.querySelector("#x");
    // let y =<HTMLInputElement> document.querySelector("#y");
    this.rowsx = Number(x.value)
    this.colsy = Number(x.value)
    this.zrobmacierz()

    console.log("zlapalo");
  }
  zrobmacierz() {
    let x: number[][] = []
    for (let i = 0; i < this.rowsx; i++) {
      let y: number[] = []
      for (let j = 0; j < this.colsy; j++) {

        y.push(0)
      }
      x.push(y)
    }
    this.macierz = x
  }
  fakearray(num: number) {
    let x = []
    for (let i = 0; i < num; i++) {
      x.push("")

    }
    return x
  }
  zmienwartosc(x: number, y: number, event: Event) {
    let val = (<HTMLInputElement>event.target).value

    this.macierz[x][y] = Number(val)
    console.log(this.macierz)
this.policzwyznacznik()
  }
  policzwyznacznik() {
    // for (let i = 0; i < this.macierz.length; i++) {
    //   for (let j = i; j <this.macierz[i].length; j++) {


    //   }  
    // }
    let suma1 = this.policzsumemacierzyjednej(this.macierz)
    console.log("s1: "+suma1)
    console.log( "macierz:")
    console.log(this.macierz)
    let odwrocona:number[][] = []
    // this.macierz.forEach(el=>{
    //   odwrocona.push(el.reverse())
    // })
    this.macierz.forEach(el=>{
      let tmprevarr:number[] =[]
      for(let i =el.length-1;i>=0;i--){
        tmprevarr.push(el[i]) 
      }
      odwrocona.push(tmprevarr)
    })
    console.log( "odwrocona:")
    console.log(odwrocona)
    console.log( "macierz:")
    console.log(this.macierz)
    let suma2=this.policzsumemacierzyjednej(odwrocona)

    console.log("s2: "+suma2)
    this.wyznacznikmacierzy=suma1-suma2

  }
  policzsumemacierzyjednej(macierz:number[][]){
    let dlugosc = macierz.length;
    let lx = 0
    let suma = 0
    let dzialania=""
    for (let i = 0; i < dlugosc; i++) {
      lx = i
      let tmp =1
      for (let j = 0; j < dlugosc; j++) {
        dzialania+=macierz[(lx+j)%dlugosc][(j)%dlugosc]+"*"
        tmp*=macierz[(lx+j)%dlugosc][(j)%dlugosc]
      }
      dzialania+="+"
      suma+=tmp
    }
    console.log(dzialania)
    // console.log(suma);
    return suma ;

  }



}
