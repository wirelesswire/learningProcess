import { Component, OnInit } from '@angular/core';
import { from } from 'rxjs';

@Component({
  selector: 'app-edytor',
  templateUrl: './edytor.component.html',
  styleUrls: ['./edytor.component.css']
})
export class EdytorComponent implements OnInit {
  text:HTMLElement = <HTMLElement>document.querySelector("#text");
  constructor() { }




  ngOnInit(): void {
    this.text = <HTMLElement>document.querySelector("#text")
  }
  dummyarray(min:number ,max:number){
    let tmp = [] 
    for (let index = min; index <= max; index++) {
      tmp.push(index)
      
    }
    return tmp

  }
  // onClick(event) {
  //   var target = event.target || event.srcElement || event.currentTarget;
  //   var idAttr = target.attributes.id;
  //   var value = idAttr.nodeValue;
  // }
  italic(event:Event){
    // console.log(event.target)
    let x :HTMLElement = <HTMLElement>event.target
    x.classList.toggle("clicked")

    this.text.classList.toggle("italic")
  }
  bold(event:Event){
    let x :HTMLElement = <HTMLElement>event.target
    x.classList.toggle("clicked")

    this.text.classList.toggle("bold")
  }
  linethrough(event:Event){
    let x :HTMLElement = <HTMLElement>event.target
    x.classList.toggle("clicked")

    this.text.classList.toggle("lineth")
    this.text.classList.remove("underline")
  }
  underline(event:Event){
    let x :HTMLElement = <HTMLElement>event.target
    x.classList.toggle("clicked")

    this.text.classList.toggle("underline")
    this.text.classList.remove("lineth")
  }

  line(xd:string,event:Event){
    let x :HTMLElement = <HTMLElement>event.target
    let z : HTMLElement[]= Array.from(document.querySelectorAll<HTMLElement>(".line"))
    // z.splice(z.indexOf(x),1)

    z.forEach(el=>{
      el.classList.remove("clicked")
    })
    x.classList.toggle("clicked")

    this.text.style.textDecoration= xd == "u"?"underline":"line-through";

  }
  size(){

    let x = <HTMLSelectElement>document.querySelector("#wielkosc")
    console.log(x.selectedOptions[0].value)

    this.text.style.fontSize = x.selectedOptions[0].value+"px"
  }
  textal(gdzie:string ,event:Event){
    let x :HTMLElement = <HTMLElement>event.target
    let z : HTMLElement[]= Array.from(document.querySelectorAll<HTMLElement>(".align"))
    z.splice(z.indexOf(x),1)
    z.forEach(el=>{
      el.classList.remove("clicked")
    })


    x.classList.toggle("clicked")




    this.text.style.textAlign = gdzie == "l"? "start":gdzie=="s"?"center":"end"
  }
  color(){

    let tmp = <HTMLInputElement>(document.querySelector("#color"))
    this.text.style.color = tmp.value
  }

  case(cas:string,event:Event){
    let x :HTMLElement = <HTMLElement>event.target
    let z:HTMLElement[] = <HTMLElement[]>[document.querySelector("#low"),document.querySelector("#up")]
    z.splice(z.indexOf(x),1)
    z.forEach(el=>{
      el.classList.remove("clicked")
    })

    x.classList.toggle("clicked")

    this.text.style.textTransform = cas=="l"?"lowercase" : "uppercase"
  }
}
