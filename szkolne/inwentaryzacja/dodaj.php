<?php
$conn = new mysqli("localhost","root","","inwentaryzacja");

$id  = $_POST['id']??"";
$id_sala = $_POST['id_sala'] ??"";
$nazwa_sala = $_POST['nazwa_sala']??"";

$nazwa_rodzaj =$_POST['nazwa_rodzaj']??"";


$sala_gdzie = $_POST['sala'];
$rodzaj_gdzie =$_POST['rodzaj'];
$ilosc_gdzie = $_POST['ilosc'];


$imie = $_POST["imie"]??"";
$nazwisko  = $_POST['nazwisko']??"";
$adres_zam = $_POST['adres_zam']??"";
$indywidualny = isset($_POST['indywidualny'])?1:0;
// $rodzaj =  $_POST['rodzaj']??"";
$klient_id =  $_POST['klient_id']??"";
$data =  $_POST['data']??"";
$zboze_id =  $_POST['zboze_id']??"";
$ile =  $_POST['ile']??"";
$nazwa_zboza =$_POST['nazwa_zboza']?? "";
var_dump($_POST);

if($nazwa_sala!=""  ){
    echo "weszło";
    $sql ="";
    if($id != ""){
        $sql ="UPDATE `sala` SET `nazwa` = '${nazwa_sala}' WHERE `sala`.`id` = $id ";
    }
    else{
        $sql = "INSERT into sala (`id`, `nazwa`) values(null,\"$nazwa_sala\")";

    }
    var_dump($sql);
    $conn->query($sql);
    
    header("location:index.php");
    exit;
}
else if($nazwa_rodzaj !=""){
    $sql ="";
    if($id != ""){
        $sql ="UPDATE `rodzaj` SET `nazwa` = '${nazwa_rodzaj}' WHERE `rodzaj`.`id` = $id ";
    }
    else{
        $sql = "INSERT into rodzaj  values(null,\"$nazwa_rodzaj\")";

    }
    var_dump($sql);
    $conn->query($sql);
    
    header("location:index.php");
    exit;
}






else if($sala_gdzie!="" && $rodzaj_gdzie !=""  && $ilosc_gdzie !=""){

    if($id!=""){
        $sql ="UPDATE `gdzie` SET `sprzet_id` = '{$rodzaj_gdzie}', `sala_id` = '${sala_gdzie}', `ilosc` = '${ilosc_gdzie}' WHERE `gdzie`.`id` = ${id}    ";
    }
    else{
        // $sql = "INSERT into klient values(null,\"$imie\",\"$nazwisko\",\"$adres_zam\",$indywidualny)";
        $sql = "INSERT INTO `gdzie` (`id`, `sprzet_id`, `sala_id`, `ilosc`) VALUES (NULL, '${rodzaj_gdzie}', '${sala_gdzie}', '${ilosc_gdzie}') ";
    }


   
    var_dump($sql);
    $conn->query($sql);
    header("location:index.php");
    exit;
}
// else if($nazwa_zboza !=""  ){
//     if($id != ""){
//         $sql ="UPDATE `zboze` SET `nazwa` = '$nazwa_zboza' WHERE `zboze`.`id_zboze` = $id ";
//     }
//     else{
//         // $sql = "INSERT into klient values(null,\"$imie\",\"$nazwisko\",\"$adres_zam\",$indywidualny)";
//         // $sql = "INSERT into op values(null,\"$rodzaj\",$klient_id,$data,$zboze_id,$ile)";
//         $sql = "INSERT into zboze values(null,\"$nazwa_zboza\")";

//     }


//     var_dump($sql);
//     $conn->query($sql);
//     header("location:index.php");
//     exit;
// }


header("location:index.php");
exit;

?>
