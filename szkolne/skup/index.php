<?php

$conn = new mysqli("localhost","root","","skup_rolny");
$id =$_GET['id']??"";
$tabela = $_GET['tabela']??"";
if($id!= "" && $tabela !=""){
    $sqlcalosc = "SELECT * FROM $tabela WHERE id_".$tabela." = ".$id;
$wartosciwpisane =$conn->query($sqlcalosc)->fetch_assoc();
}
// $wartosciwpisane =[];
// var_dump($sqlcalosc);
// var_dump($wartosciwpisane);
?>
klient
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        #wraper{
            display:flex;
        }
        .tabela{
            flex:1;
        }
    </style>
</head>
<body>
    
</body>
</html>

<form action="dodaj.php" method="POST">
<input type="hidden" name="id" value="<?= $id!="" && $tabela =="klient" ?$id:"" ?>">
<input type="text" name="imie"     value="<?= $id!="" && $tabela =="klient" ? $wartosciwpisane['imie']:"" ?>" >
<input type="text" name="nazwisko" value="<?= $id!="" && $tabela =="klient" ? $wartosciwpisane['nazwisko']:"" ?>" >
<input type="text" name="adres_zam" value="<?= $id!="" && $tabela =="klient" ? $wartosciwpisane['adres_zam']:"" ?>" >
<input type="checkbox" name="indywidualny"  <?= $id!="" && $tabela =="klient" ? $wartosciwpisane['indywidualny']=="1"? "checked" :""   :"" ?>> czy jest klientem indywidualnym
<input type="submit" value="submit">

</form>




operacja
<form action="dodaj.php" method="POST">
<input type="hidden" name="id" value=<?= $id!=""&& $tabela =="op" ?$id:"" ?>>
<select name ="rodzaj">
<?php
foreach ($conn->query("SELECT DISTINCT rodzaj  from op") as $key => $value) {
    ?>
    <option  <?= $id!="" && $tabela =="op" ? $wartosciwpisane['rodzaj']==$value['rodzaj'] ? "selected" :""   :"" ?>   ><?=    $value['rodzaj']?></option>;
    <?php
}
?>

</select>
<select name ="klient_id">
<?php
foreach ($conn->query("SELECT DISTINCT id_klient, imie,nazwisko from klient") as $key => $value) {
    ?>
    <option value="<?=$value['id_klient']?>"   <?= $id!="" && $tabela =="op" ? $wartosciwpisane['klient_id']==$value['id_klient'] ? "selected" :""   :"" ?>   ><?= $value['id_klient']." ". $value['imie']." ".$value['nazwisko']?></option>;
    <?php
    // echo "<option value=\"".$value['id_klient']."\"> ".$value['id_klient']." ". $value['imie']." ".$value['nazwisko'] . " </option>";
}
?>
</select>

<input type="date" name="data"  value="<?= $id!="" && $tabela =="op" ? $wartosciwpisane['kiedy']:"" ?>">

<select name ="zboze_id">
<?php
foreach ($conn->query("SELECT  id_zboze, nazwa from zboze") as $key => $value) {
    ?>
    <option value="<?=$value['id_zboze']?>"   <?= $id!="" && $tabela =="op" ? $wartosciwpisane['zboze_id']==$value['id_zboze'] ? "selected" :""   :"" ?> ><?= $value['nazwa']?></option>;
    <?php
}
?>
</select>


<input type="number" name="ile" id=""  placeholder ="ilosc"  value="<?= $id!="" && $tabela =="op" ? $wartosciwpisane['ile']:0 ?>"> 


<input type="submit" value="submit">
</form>





dodaj nowe zboze
<form action="dodaj.php" method="POST">
<input type="hidden" name="id" value=<?= $id!=""&& $tabela =="zboze" ?$id:"" ?>>

<input type="text" name="nazwa_zboza" value="<?= $id!="" && $tabela =="zboze" ? $wartosciwpisane['nazwa']:"" ?>  ">

<input type="submit" value="submit">

</form>
<div id="wraper">
<div class="tabela">
<?php



    $x = $conn->query("SELECT * FROM klient");
 
    echo "<table>";
    echo "<tr>";
    echo "<td>id</td>";
    echo "<td>imie</td>";
    echo "<td>nazwisko</td>";
    echo "<td>adres</td>";
    echo "<td>indywidualny</td>";
    echo "<td>usun</td>";
    echo "<td>edytuj</td>";
    echo "</tr>";
    foreach ($x as $key => $value) {
        echo "<tr>";
        echo "<td>".$value["id_klient"]."</td>";
        echo "<td>".$value["imie"]."</td>";
        echo "<td>".$value["nazwisko"]."</td>";
        echo "<td>".$value["adres_zam"]."</td>";
        if($value['indywidualny'] =="0"){
            echo  "<td> nie </td>";
        }
        else if($value['indywidualny'] == "1"){
        echo "<td>tak</td>";
        }
        else{
            echo "<td>złe dane</td>"; 
        }
        echo "<td><a href=\"usun.php?id=".$value['id_klient']."&tabela=klient\"> usun</a></td>";
        echo "<td><a href=\"index.php?id=".$value['id_klient']."&tabela=klient\"> edytuj</a></td>";
        echo "</tr>";
    }
    echo"</table>";

?>
</div>








<div class="tabela">
<?php

$x = $conn->query("SELECT * FROM op order by id_op desc");

    echo "<table>";
    echo "<tr>";
    echo "<td>id</td>";
    echo "<td>rodzaj</td>";
    echo "<td>klient_id</td>";
    echo "<td>kiedy</td>";
    echo "<td>zboze</td>";
    echo "<td>ile</td>";
    echo "<td>usun</td>";
    echo "<td>edytuj</td>";
    echo "</tr>";
    foreach ($x as $key => $value) {
        echo "<tr>";
        echo "<td>".$value["id_op"]."</td>";
        echo "<td>".$value["rodzaj"]."</td>";
        echo "<td>".$value["klient_id"]."</td>";
        echo "<td>".$value["kiedy"]."</td>";
        echo "<td>".$value["zboze_id"]."</td>";
        
        echo "<td>".$value["ile"]."</td>";
        echo "<td><a href=\"usun.php?id=".$value['id_op']."&tabela=op\"> usun</a></td>";
        echo "<td><a href=\"index.php?id=".$value['id_op']."&tabela=op\"> edytuj</a></td>";

        echo "</tr>";
    }
    echo"</table>";

?>
</div>









<div class="tabela">
<?php

$x = $conn->query("SELECT * FROM zboze ");
 
    echo "<table>";
    echo "<tr>";
    echo "<td>id</td>";
    echo "<td>nazwa</td>";
    echo "<td>usun</td>";

    echo "</tr>";
    foreach ($x as $key => $value) {
        echo "<tr>";
        echo "<td>".$value["id_zboze"]."</td>";
        echo "<td>".$value["nazwa"]."</td>";
        echo "<td><a href=\"usun.php?id=".$value['id_zboze']."&tabela=zboze\"> usun</a></td>";
        echo "<td><a href=\"index.php?id=".$value['id_zboze']."&tabela=zboze\"> edytuj</a></td>";

        echo "</tr>";
    }
    echo"</table>";

?>
</div>

















</div>
