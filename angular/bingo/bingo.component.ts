import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bingo',
  templateUrl: './bingo.component.html',
  styleUrls: ['./bingo.component.css']
})
export class BingoComponent implements OnInit {

  constructor() { }
  tmppole :pole[]=[
    {name:"kataklizm",checked:false},
    {name:"kataklizm2",checked:false},
    {name:"kataklizm3",checked:false},
    {name:"kataklizm4",checked:false},
]
  pola:pole[][] =[ [
    {name:"kataklizm",checked:false},
    {name:"kataklizm2",checked:false},
    {name:"kataklizm3",checked:false},
    {name:"kataklizm4",checked:false},
],


]
isbingo:boolean =false;

  ngOnInit(): void {
   this.startuj()
  }

  startuj(){
    let tmppola = this.tmppole
    tmppola.forEach(el=>{
      el.checked = false;
    })    
    this.pola=[]
    for (let i = 0; i < this.tmppole.length; i++) {
      this.pola.push(tmppola);
    }
    this.isbingo=false
  }



  reset(){
    this.startuj()
  }
  klik(x:number,y:number){
    if(this.isbingo){
      return
    }
    let tmp = document.querySelector("#pole"+x+y)
    tmp?.classList.toggle("checked");
    tmp?.classList.toggle("unchecked");
    this.pola[x][y].checked = !this.pola[x][y].checked
    if(this.przeliczCzybingo()){
      this.jestbingo();
    }    
  }
  przeliczCzybingo(){
    // for (let x = 0; x < this.pola.length; x++) {
    //   const element = this.pola[x];
    //   let isrow=true;
    //   for (let y = 0; y < element.length; y++) {
    //     const el = element[y];
    //     if(el.checked == false){
    //       isrow = false;
    //     }
    //   }
    //   if(isrow){
    //     return  true
    //   }
    // }
    // for (let a = 0; a < this.pola[0].length; a++) {
    //   let istrue=true
    //   for (let b = 0; b < this.pola.length; b++) {
    //     console.log(b+""+a +this.pola[b][a].checked)
    //     if(this.pola[b][a].checked ==false){
          
    //       istrue =false
    //     }
    //   }
    //   if(istrue){
    //     return true
    //   }
    // }
    for (let index = 0; index < this.pola[0].length; index++) {
      const element = this.pola[0][index];
      let iscol=true;
      for (let b = 0; b < this.pola[index].length; b++) {
        console.log(this.pola[b][index].checked)
        if(this.pola[b][index].checked ==false){
          iscol =false
          console.log("zmieniło")
        }        
      }
      if(iscol == true){
        return iscol;
      }
    }
    return false;
  }
  jestbingo(){
    console.log("bingo")
    this.isbingo=true;
  }

}
interface pole{
  name:string,
  checked:boolean;
}
