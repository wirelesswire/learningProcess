<?php
session_start();
$conn = new mysqli("localhost","root","","inwentaryzacja");
$id= $_GET['id'] ??"";
$tabela= $_GET['tabela']??"";
if($id != "" && $tabela !=""){
   if($tabela == "sala" ){
    $sql = "SELECT * FROM `sala` JOIN gdzie on gdzie.sala_id = sala.id WHERE sala.id = ${id}";
    if($tmp = $conn->query($sql)->num_rows >0){
        $_SESSION['err']=" ma coś przypisane nie możesz usunąć";
        
    header("location:index.php");
    exit();
    }
//  var_dump($sql);
//  var_dump($tmp);

   }
   if($tabela =="rodzaj"){
       $sql = "SELECT * FROM `rodzaj` join gdzie on gdzie.sprzet_id = rodzaj.id where rodzaj.id = ${id};";
    if($tmp = $conn->query($sql)->num_rows >0){
        $_SESSION['err']=" ma coś przypisane nie możesz usunąć";
                
        header("location:index.php");
        exit();
    }

   }

    $sql ="DELETE FROM " . $tabela ." WHERE id =".$id;
    var_dump($sql);
    $conn->query($sql);
}

header("location:index.php");
exit();