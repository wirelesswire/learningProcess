<?php
$conn = new mysqli("localhost","root","","skup_rolny");
$id= $_GET['id'] ??"";
$tabela= $_GET['tabela']??"";
if($id != "" && $tabela !=""){
    $nazwaid=[
        "klient"=>"id_klient",
        "op"=>"id_op",
        "zboze"=>"id_zboze",

    ];
    $sql ="DELETE FROM " . $tabela ." WHERE id_".$tabela."=".$id;
    var_dump($sql);
    $conn->query($sql);
}
else{
    
}
header("location:index.php");
exit();