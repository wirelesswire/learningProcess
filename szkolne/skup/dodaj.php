<?php
$conn = new mysqli("localhost","root","","skup_rolny");

$id  = $_POST['id']??"";
$imie = $_POST["imie"]??"";
$nazwisko  = $_POST['nazwisko']??"";
$adres_zam = $_POST['adres_zam']??"";
$indywidualny = isset($_POST['indywidualny'])?1:0;
$rodzaj =  $_POST['rodzaj']??"";
$klient_id =  $_POST['klient_id']??"";
$data =  $_POST['data']??"";
$zboze_id =  $_POST['zboze_id']??"";
$ile =  $_POST['ile']??"";
$nazwa_zboza =$_POST['nazwa_zboza']?? "";
var_dump($_POST);

if($imie !="" && $nazwisko !="" && $adres_zam !="" && $indywidualny !=""  ){
    echo "weszło";
    $sql ="";
    if($id != ""){
        $sql ="UPDATE `klient` SET `imie` = '${imie}', `nazwisko` = '${nazwisko}', `adres_zam` = '${adres_zam}', `indywidualny` = '${indywidualny}' WHERE `klient`.`id_klient` = $id ";
    }
    else{
        $sql = "INSERT into klient values(null,\"$imie\",\"$nazwisko\",\"$adres_zam\",$indywidualny)";

    }
    var_dump($sql);
    $conn->query($sql);
    header("location:index.php");
    exit;
}

else if($rodzaj !="" &&$klient_id !="" &&$data !="" &&$zboze_id !=""&&$ile !=""  ){
    if($id != ""){
        $sql ="UPDATE `op` SET  `rodzaj` = '$rodzaj', `klient_id` = '$klient_id', `kiedy` = '$data', `zboze_id` = '$zboze_id', `ile` = '$ile' WHERE `op`.`id_op` = $id   ";
    }
    else{
        // $sql = "INSERT into klient values(null,\"$imie\",\"$nazwisko\",\"$adres_zam\",$indywidualny)";
        $sql = "INSERT into op values(null,\"$rodzaj\",$klient_id,$data,$zboze_id,$ile)";
    }


   
    var_dump($sql);
    $conn->query($sql);
    header("location:index.php");
    exit;
}
else if($nazwa_zboza !=""  ){
    if($id != ""){
        $sql ="UPDATE `zboze` SET `nazwa` = '$nazwa_zboza' WHERE `zboze`.`id_zboze` = $id ";
    }
    else{
        // $sql = "INSERT into klient values(null,\"$imie\",\"$nazwisko\",\"$adres_zam\",$indywidualny)";
        // $sql = "INSERT into op values(null,\"$rodzaj\",$klient_id,$data,$zboze_id,$ile)";
        $sql = "INSERT into zboze values(null,\"$nazwa_zboza\")";

    }


    var_dump($sql);
    $conn->query($sql);
    header("location:index.php");
    exit;
}


header("location:index.php");
exit;

?>
