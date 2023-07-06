
 let inputimie = document.querySelector("#inputimie");
 let inputemail = document.querySelector("#inputemail");
 let inputtelefon = document.querySelector("#inputtelefon");
let diva= document.querySelector("#div");
let formbtn =document.querySelector("#submitbtn");
function waliduj(){
   
    diva.innerHTML="";
    tekst ="";
    dzialaczynie =true;
    if(inputimie.value.length>0){
    // if(!isNaN( (Number)(inputtelefon.value))){
    //     console.log(inputimie.value);
    // // }   
    // else{

    // }
    arr  =inputimie.value.trim().split(" ");
    console.log(inputimie.value.trim());
    if(arr.length==2){
        console.log(arr);
        console.log("działa");
    }
    else{
        tekst +="złe  format imienia  lub nazwiska ";
        dzialaczynie= false;
    }
   

    
    }
    if(inputemail.value.length>0){
        // if(!isNaN( (Number)(inputtelefon.value))){
        //     console.log(inputimie.value);
        // // }   
        // else{
    
        // }
        tmp =inputemail.value;
        if(tmp.indexOf("@")!=-1 && tmp.lastIndexOf(".")>tmp.indexOf("@") && tmp.lastIndexOf(".") !=tmp.length-1){
            
            
        }
        else{
            dzialaczynie = false;
            tekst+=" email jes niepoprawny ";
            console.log("nie ma małpy")
        }
    } 
    else{
            dzialaczynie =false;
    }
    if(inputtelefon.value.length>0){
        if(!isNaN( (Number)(inputtelefon.value)) && inputtelefon.value.length==9 ){
            console.log(inputimie.value);
        }   
        else{
            dzialaczynie=false;
            tekst+=" numer telefonu jest niepoprawny ";
        }
        // tmp =inputemail.value;
        // if(tmp.indexOf("@")!=-1 && tmp.lastIndexOf(".")>tmp.indexOf("@") && tmp.lastIndexOf(".") !=tmp.length-1){
            
            
        // }
        // else{
        //     dzialaczynie = false;
        //     tekst+="email jes niepoprawny";
        //     console.log("nie ma małpy")
        // }
    } 
    else{
            dzialaczynie =false;
    }
    document.querySelector("#submitbtn").disabled= ! dzialaczynie
    diva.innerHTML=tekst;
    return dzialaczynie;
}


inputimie.addEventListener("input",()=>{
    waliduj();
    // console.log(inputimie.value);
})

inputemail.addEventListener("input",()=>{
    waliduj();

    // console.log(inputimie.value);
})
inputtelefon.addEventListener("input",()=>{
    waliduj();

    // console.log(inputimie.value);
})


