<?php
$conn = new mysqli("localhost","root","","buty");

if($_POST!=null){
$nazwa = $_POST['nazwa'];
$cena  = $_POST['cena'];
$nowe = 0;
if( isset( $_POST['nowe'])){
$nowe =1;
}
$isoktoputtodb =true;
if(!$nazwa){
    echo "nie podałeś nazwy </br>";
    $isoktoputtodb =false;
}
if(!$cena ){
    echo " nie podałeś ceny</br>";
    $isoktoputtodb =false;
}
if( $isoktoputtodb){
$kiedy = date("Y-m-d H:i:s");

// $sql = "INSERT into buty values(null,`$nazwa`,`$kiedy`,`$cena`,`$nowe`)";
$sql ="INSERT INTO `buty` (`id`, `nazwa`, `kiedy`, `cena`, `nowe`) VALUES (null,'${nazwa}','{$kiedy}','${cena}','{$nowe}')";
var_dump($sql);
$conn->query($sql);
    header("location:lista.php");
    // exit;
}
}

?>
<a href="index.php">