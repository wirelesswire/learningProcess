<pre>
<?php
$conn = new mysqli("localhost","root","","sklep");
var_dump($_GET);

$data = $_GET["data"];
$sklepid =$_GET['sklepid']; 
if($data!=""){
    $sql = "INSERT INTO `zakup` (`id`, `sklep_id`, `data_zakupu`) VALUES (NULL, ${sklepid}, '${data}')";
     $conn->query($sql);
     
}
header("location:sklep.php");
exit;