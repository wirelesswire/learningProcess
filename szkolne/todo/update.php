<?php

$conn = new mysqli("localhost","root","","todoapp");
$gdzie =$conn->query("SELECT * FROM gdzie");
$stan = $conn->query("SELECT * FROM stan");
$id=null;
if(isset($_GET['id'])){
    $id=$_GET['id'];
}
else{
    header("location:todo.php");
    exit;
}
$tendoupateu= $conn->query("SELECT * FROM wszystkie where id = ".$id)->fetch_assoc();


$opis_val=$tendoupateu['opis'] ?? "";
$gdzie_val = $tendoupateu['gdzie_id']??1;
$stan_val =$tendoupateu['stan_id']??1;
$data_val = $tendoupateu['data'] ?? date("d-m-Y");

?>

<form action="dodaj.php?id=<?=$id?>" method="GET">
<input type="text" name="opis" value="<?= $opis_val?>">


<select name="gdzie" id="">
<?php
foreach ($gdzie as $key => $value) {
    ?>
    <option value =<?=$value['id'] ?>  <?= $gdzie_val==$value['id'] ? "selected":""  ?>>  <?=$value['nazwa']?></option>
<?php
}

?>
</select>

<select name="stan" id="">
<?php
foreach ($stan as $key => $value) {
    ?>
    <option value =<?=$value['id'] ?>  <?= $stan_val==$value['id'] ? "selected":""  ?>>  <?=$value['nazwa']?></option>
<?php
}

?>
</select>
<input type="hidden" name="id" value=<?=$id?>>
<input type="date" name="data" value = <?=$data_val ?>>
<input type="submit"  name="update" value="zaktualizuj">
</form>