<?php
$conn = new mysqli("localhost","root","","todoapp");    
var_dump($_GET);
$opis_val=$_GET['opis'] ?? "";
$gdzie_val = $_GET['gdzie']??1;
$stan_val =$_GET['stan']??1;
$data_val = $_GET['data'] ?? date("d-m-Y");
$cozrobic=$_GET['dodaj'] ?? $_GET['update']?? null;
if(isset($_GET['dodaj'])){
$sql = "INSERT INTO `wszystkie` (`id`, `opis`, `gdzie_id`, `stan_id`, `data`) VALUES (NULL, '${opis_val}', '${gdzie_val}', '${stan_val}', '${data_val}')";
$conn->query($sql);
header("location:todo.php");
exit;

}
elseif (isset($_GET['update'])){
$sqlupdate ="UPDATE `wszystkie` SET `opis` = '${opis_val}', `gdzie_id` = '${gdzie_val}', `stan_id` = '${stan_val}', `data` = '${data_val}' WHERE `wszystkie`.`id` =".$_GET['id'];
$conn->query($sqlupdate);
header("location:todo.php");
exit;

}
else{
    echo"błąd";
}

