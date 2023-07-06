<?php
$conn = new mysqli("localhost","root","","sklep");

?>
<form  action="dodajzakup.php" method="GET">

<select name="sklepid">
<?php 
foreach ($conn->query("SELECT * FROM sklep") as $key => $value) {
    ?>
    <option value="<?=$value['id'] ?>" ><?=$value['nazwa'] ?></option>
    <?php
}


?>

</select>
<input name="data" type="date">
<input type="submit" value="dodaj zakup" >

</form>

<form method="GET" action="dodajtowar.php">
<select name = "zakupid">
<?php
$dql ="SELECT zakup.id,sklep_id,data_zakupu,nazwa FROM zakup join sklep on sklep.id =zakup.sklep_id; ";
// var_dump($dql);
foreach ($conn->query($dql) as $key => $value) {
    ?>
    <option value="<?=$value['id']?>" ><?= $value['id']."  ".$value['data_zakupu']." ".$value['nazwa'] ?> </option>
    <?php
}

?>

</select>
<input name ="nazwatowaru" type = "text" placeholder="nazwa towaru">
<input name="cenazasztuke" type="number" placeholder="cena za sztuke">
<input name="iloscsztuk" type="number" placeholder="ilosc sztuk">
<input type="submit" value="dodaj zakup" >

</form>


<table>
<tr>
<td></td>
<td></td>


</tr>



<?php



$sql2 = "SELECT zakup.id,sklep_id,data_zakupu,nazwa FROM zakup join sklep on sklep.id = zakup.sklep_id;";
$wyniki = $conn->query($sql2);
foreach ($wyniki as $key => $value) {
    $tmp ="sklep.php?idzakupu=".$value['id'];
    $tmp2 = "usun.php?co=zakup&id=".$value['id'];
    ?>
    <tr>
        
        <td><?=$value["id"]?></td>
        <td><a href="<?=$tmp?>"><?=$value['nazwa']?></a></td>
        <td><?=$value['data_zakupu']?></td>
        <td><a href="<?=$tmp2?>">usun</a></td>
        
    </tr>
    <?php
}

?>
</table>
<?php
$idzakupuktoremabycwyswietlone=$_GET['idzakupu']?? -1;
if($idzakupuktoremabycwyswietlone!=-1){
    $sql1 ="SELECT towary.id, data_zakupu,nazwa,cena,ile_sztuk FROM `zakup` join towary on towary.zakup_id = zakup.id  WHERE zakup.id =" .$idzakupuktoremabycwyswietlone;
    $wyn = $conn->query($sql1);
    ?>
    
    <ul>
    <?php
    foreach ($wyn as $key => $value) {
        echo "<li>".$value['data_zakupu']." ".$value['nazwa']." ".$value['cena']."zł ".$value['ile_sztuk']." sztuk"."  <a href='"."usun.php?co=towar&id=".$value['id']."'>usun"."</a>"."</li>";
    }

    ?>
    </ul>

<?php
}




