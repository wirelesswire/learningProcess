<pre>
<?php
$conn = new mysqli("localhost","root","","sklep");
var_dump($_GET);
$co=$_GET['co']??"";
$id =$_GET['id']??0;
if($co!=""&& $id!=0){
    $sql = [];
    if($co == "towar"){
        $sql[] = "DELETE FROM towary WHERE `id` =".$id;
    }
    else if($co == "zakup"){
        $sql[] = "DELETE FROM zakup WHERE `id` =".$id;
        $sql[] = "DELETE FROM towary WHERE `zakup_id`=".$id;
    }
    foreach ($sql as $key => $value) {
        var_dump($value);
        $conn->query($value);
    }
    var_dump($sql);
}
header("location:sklep.php");
exit();


?>