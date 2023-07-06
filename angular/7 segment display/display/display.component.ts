import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css']
})
export class DisplayComponent implements OnInit {

  constructor() { }
  
  numbers:numb[]=[
    {num:0,numberslit:[1,2,3,4,5,6]},
    {num:1,numberslit:[2,3]},
    {num:2,numberslit:[1,2,7,5,4]},
    {num:3,numberslit:[1,2,3,4,7]},
    {num:4,numberslit:[2,3,6,7]},
    {num:5,numberslit:[1,3,4,6,7]},
    {num:6,numberslit:[1,3,4,5,6,7]},
    {num:7,numberslit:[1,2,3]},
    {num:8,numberslit:[1,2,3,4,5,6,7]},
    {num:9,numberslit:[1,2,3,6,7]},
  ]

  ngOnInit(): void {
  }
  klik(event:Event){
    let x :HTMLElement = <HTMLElement> event.target
    x.classList.toggle("clicked")

  }
}
interface numb{
  num:number,
  numberslit:number[]

}