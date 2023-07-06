<?php

$conn = new mysqli("localhost","root","","sklep");
var_dump($_GET);
$zakupid = $_GET['zakupid'] ?? -1;
$nazwatowaru = $_GET['nazwatowaru'] ?? "";
$cenazasztuke = $_GET['cenazasztuke'] ?? 0 ;
$iloscsztuk = $_GET['iloscsztuk'] ?? 0;

if($zakupid !=-1 && $nazwatowaru !="" && $cenazasztuke != 0 && $iloscsztuk!=0){
    $sql ="INSERT INTO `towary` (`id`, `zakup_id`, `nazwa`, `cena`, `ile_sztuk`) VALUES (NULL, $zakupid, '${nazwatowaru}', ${cenazasztuke}, ${iloscsztuk});";
    // var_dump($sql);
    $conn->query($sql);


}

header("location:sklep.php");
exit;