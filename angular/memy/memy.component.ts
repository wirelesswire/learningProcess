import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-memy',
  templateUrl: './memy.component.html',
  styleUrls: ['./memy.component.css']
})
export class MemyComponent implements OnInit {
  memes: meme[] = []
  ostatniooceniony: meme | null = null;
  losowy: meme = { nazwa: "meme", path: "asd", oceny: [] };
  constructor() {

    // this.losowy = this.memes[this.getRandomIntInclusive(0,this.memes.length-1)]

  }
  ocen(idx: number) {
    let x = <HTMLInputElement>document.querySelector("#img" + idx);
    this.memes[idx].oceny.push(Number(x.value) <= 10 ? Math.abs(Number(x.value)) : 10);
    x.value = ""
    this.ostatniooceniony = this.memes[idx]
    this.sortuj();
    this.zapisz();
  }
  sredniaOcen(x: meme) {
    if (x.oceny.length == 0) {
      return 0;
    }
    let suma = 0

    for (let i = 0; i < x.oceny.length; i++) {
      const element = x.oceny[i];
      suma += element;
    }
    return suma / x.oceny.length
  }
  getRandomIntInclusive(min: number, max: number) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
  }

  zapisz() {
    localStorage.setItem("memy",JSON.stringify(this.memes))
    localStorage.setItem("ostatnio",JSON.stringify(this.ostatniooceniony))

  }
  ngOnInit(): void {
    let tmpstring = localStorage.getItem("memy")
    let tmpstring2 = localStorage.getItem("ostatnio")
    if (tmpstring != null && tmpstring2!=null) {
      // localStorage.setItem("memy","to cos ");
      this.memes = JSON.parse(tmpstring);
      this.ostatniooceniony = JSON.parse(tmpstring2)


    }
    else {
      for (let i = 1; i < 10; i++) {
        // const element = ;
        this.memes.push({ nazwa: "meme" + i, path: "assets/meme" + i + ".jpg", oceny: [] });
      }
    }

    this.losujmema()
    setInterval(() => { this.losujmema() }, 10000)

  }
  losujmema() {
    this.losowy = this.memes[this.getRandomIntInclusive(0, this.memes.length - 1)]
  }
  sortuj() {

    for (let i = 0; i < this.memes.length - 1; i++) {
      for (let j = 0; j < this.memes.length - 1; j++) {
        if (this.sredniaOcen(this.memes[j]) == this.sredniaOcen(this.memes[j + 1])) {
          if (this.memes[j].oceny.length <= this.memes[j + 1].oceny.length) {

            let tmp = this.memes[j]
            this.memes[j] = this.memes[j + 1];
            this.memes[j + 1] = tmp;
          }
          else {

            let tmp = this.memes[j + 1]
            this.memes[j + 1] = this.memes[j];
            this.memes[j] = tmp;
          }
        }
      }
    }
    for (let i = 0; i < this.memes.length - 1; i++) {
      for (let j = 0; j < this.memes.length - 1; j++) {
        if (this.sredniaOcen(this.memes[j]) < this.sredniaOcen(this.memes[j + 1])) {
          let tmp = this.memes[j]
          this.memes[j] = this.memes[j + 1];
          this.memes[j + 1] = tmp;
        }

      }
    }



  }
  wypiszOceny(mem: meme) {
    let string = "";
    for (let index = 0; index < mem.oceny.length; index++) {
      const element = mem.oceny[index];
      string += element + ","
    }
    return string
  }


}
interface meme {
  nazwa: string,
  path: string,
  oceny: number[],

}