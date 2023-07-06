import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  pola: pole[][] = [
    [],
    [],
    []
  ]
  mozliwosci = [
    {name:"muchomor",path:"assets/muchomor.jpg",isopen:false},
    {name:"sliwka",path:"assets/sliwka.jpg",isopen:false},
    {name:"buty",path:"assets/buty.jpg",isopen:false},
    {name:"kwadrat",path:"assets/kwadrat.jpg",isopen:false}
  
  
  
  ]
  gridwielkosc= 6;
  picked:pole|null = null ;

  constructor() { }

  ngOnInit(): void {
    this.makepola();
  }

  makepola(){
    let licznik = 0
    let prefaby:pole[] = [] 
    for(let i =0 ; i<this.gridwielkosc;i++){
      prefaby.push({name:element.name,path:element.path,isopen:element.isopen,licznik:licznik});
      licznik++
    }


    let licznik = 0
    for (let i = 0; i  <4; i++) {
      let ele:pole[]=[]
      for (let i = 0; i < this.mozliwosci.length; i++) {
        const element = this.mozliwosci[i];
        // const element = this.mozliwosci[i];
        ele.push({name:element.name,path:element.path,isopen:element.isopen,licznik:licznik})
        // this.mozliwosci[i].name+=1;
        // this.pola.push([element])
        licznik++;
      }
      this.pola.push(ele)
      ele.sort(()=>0.5-Math.random())

    }
    this.mieszaj();
  
  }
  mieszaj(){
    this.pola.sort(()=>0.5-Math.random())
  }

  klik(x:number,y:number){
    if(this.picked == null){
      this.pola[x][y].isopen = true
      this.picked = this.pola[x][y]
      console.log( +"   "+x+""+y)
    }
    else{
      this.pola[x][y].isopen = true
    //   this.picked = null 
      if(this.picked.path ==this.pola[x][y].path )
      {
        console.log("zgadłeś")
        this.picked = null 
      }
      else{
       
        
        let tmp:pole = this.picked
     
        this.picked = null 
        setTimeout(()=>{
          this.pola[x][y].isopen = false
          tmp.isopen = false
        },500)
      }
    }

  }

}
interface pole {
  name: string;
  path: string;
  isopen:boolean ;
  licznik:number
}