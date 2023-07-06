<?php

$conn = new mysqli("localhost","root","","inwentaryzacja");
$id =$_GET['id']??"";
$tabela = $_GET['tabela']??"";
if($id!= "" && $tabela !=""){
    $sqlcalosc = "SELECT * FROM $tabela WHERE id = ".$id;
    $wartosciwpisane =$conn->query($sqlcalosc)->fetch_assoc();
}
// $wartosciwpisane =[];
// var_dump($sqlcalosc);
// var_dump($wartosciwpisane);
?>
inwentaryzacja
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
        #raportywrap{
            display:flex;
        }
        .raporty{
            padding :20px;
            flex:1;
        }
        table{
            border-collapse:collapse;
            border-radius:5px;  
        }
        td{
            border:1px solid black;
            border-radius:5px;
        }
        /* tr:nth-child(even){
            background-color: rgb(62, 154, 235);
        }
        tr:nth-child(odd){
            background-color: rgb(50, 100, 180);
        } */
        #errbox{
            color:white;
            background-color:red;
        }
    </style>
</head>
<body>
    
</body>
</html>
<?php
session_start();
if(isset( $_SESSION['err'])){
    ?>
    <div id="errbox"><?=$_SESSION['err']?></div>
    

    <?php
    unset($_SESSION['err']);
}


?>


<form action="dodaj.php" method="POST">
    sala
<input type="hidden" name="id" value="<?= $id!="" && $tabela =="sala" ?$id:"" ?>">
<input type="text" name="nazwa_sala" value="<?= $id!="" && $tabela =="sala" ? $wartosciwpisane['nazwa']:"" ?>">

<input type="submit" value="submit">

</form>



<form action="dodaj.php" method="POST">
rodzaj
<input type="hidden" name="id" value=<?= $id!=""&& $tabela =="rodzaj" ?$id:"" ?>>

<input type="text" name="nazwa_rodzaj" value="<?= $id!="" && $tabela =="rodzaj" ? $wartosciwpisane['nazwa']:"" ?>">

<input type="submit" value="submit">

</form>








<form action="dodaj.php" method="POST">
gdzie
<input type="hidden" name="id" value=<?= $id!=""&& $tabela =="gdzie" ?$id:"" ?>>
<select name ="sala">
<?php
foreach ($conn->query("SELECT id ,nazwa from sala") as $key => $value) {
    ?>
    <option value="<?=$value['id']?>"   <?= $id!="" && $tabela =="gdzie" ? $wartosciwpisane['id']==$value['id'] ? "selected" :""   :""     ?>    ><?=    $value['nazwa']?></option>;
    <?php
}
?>

</select>



<select name ="rodzaj">
<?php



foreach ($conn->query("SELECT DISTINCT id, nazwa from rodzaj") as $key => $value) {
    ?>
    <option value="<?=$value['id']?>"   <?= $id!="" && $tabela =="gdzie" ? $wartosciwpisane['id']==$value['id'] ? "selected" :""   :"" ?>   ><?=  $value['nazwa']?></option>;
    <?php
   
}
?>
</select>

<input type="number" name="ilosc" id=""  placeholder ="ilosc"  value="<?= $id!="" && $tabela =="gdzie" ? $wartosciwpisane['ilosc']:0 ?>"> 


<input type="submit" value="submit">
</form>






<div id="wraper">
<div class="tabela">
<?php



    $x = $conn->query("SELECT * FROM sala");
 
    echo "<table>";
    echo "<tr>";
    echo "<td>id</td>";
    echo "<td>nazwa</td>";

    echo "<td>usun</td>";
    echo "<td>edytuj</td>";
    echo "</tr>";
    foreach ($x as $key => $value) {
        echo "<tr>";
        echo "<td>".$value["id"]."</td>";
        echo "<td>".$value["nazwa"]."</td>";
        echo "<td><a href=\"usun.php?id=".$value['id']."&tabela=sala\"> usun</a></td>";
        echo "<td><a href=\"index.php?id=".$value['id']."&tabela=sala\"> edytuj</a></td>";
        echo "</tr>";
    }
    echo"</table>";

?>
</div>








<div class="tabela">
<?php

$x = $conn->query("SELECT gdzie.id as id, sprzet_id,sala_id,rodzaj.nazwa as sprzet_nazwa,sala.nazwa as sala_nazwa,ilosc 
FROM `gdzie` join rodzaj on rodzaj.id =sprzet_id join sala on sala.id = sala_id;");

    echo "<table>";
    echo "<tr>";
    echo "<td>id</td>";
    echo "<td>sala</td>";
    echo "<td>sprzet</td>";
    echo "<td>ilosc</td>";

    echo "<td>usun</td>";
    echo "<td>edytuj</td>";
    echo "</tr>";
    foreach ($x as $key => $value) {
        echo "<tr>";
        echo "<td>".$value["id"]."</td>";
        echo "<td>".$value["sala_nazwa"]."</td>";
        echo "<td>".$value["sprzet_nazwa"]."</td>";
       
        echo "<td>".$value["ilosc"]."</td>";
   
        
    
        echo "<td><a href=\"usun.php?id=".$value['id']."&tabela=gdzie\"> usun</a></td>";
        echo "<td><a href=\"index.php?id=".$value['id']."&tabela=gdzie\"> edytuj</a></td>";

        echo "</tr>";
    }
    echo"</table>";

?>
</div>









<div class="tabela">
<?php

$x = $conn->query("SELECT * FROM rodzaj ");
 
    echo "<table>";
    echo "<tr>";
    echo "<td>id</td>";
    echo "<td>nazwa</td>";
    echo "<td>usun</td>";
    echo "<td>edytuj</td>";
    echo "</tr>";
    foreach ($x as $key => $value) {
        echo "<tr>";
        echo "<td>".$value["id"]."</td>";
        echo "<td>".$value["nazwa"]."</td>";
        echo "<td><a href=\"usun.php?id=".$value['id']."&tabela=rodzaj\"> usun</a></td>";
        echo "<td><a href=\"index.php?id=".$value['id']."&tabela=rodzaj\"> edytuj</a></td>";

        echo "</tr>";
    }
    echo"</table>";

?>
</div>




</div>


<div id="raportywrap">
<div class="raporty">
<?php
$sale = $conn->query("SELECT  id,nazwa from sala");

foreach ($sale as $key => $value) {
    echo "<h2>". $value['nazwa']."</h2>";
    $wyn = $conn->query("SELECT  gdzie.id as id, sprzet_id,sala_id,rodzaj.nazwa as sprzet_nazwa,sala.nazwa as sala_nazwa,sum(ilosc) as ilosc 
    FROM `gdzie` join rodzaj on rodzaj.id =sprzet_id join sala on sala.id = sala_id where sala_id =". $value['id']." group by sprzet_id;");
    // var_dump($wyn);
    if($wyn->num_rows != 0){
    ?>
    <table>
        <tr>
            <td>sala</td>
            <td>nazwa</td>
            <td>ilosc</td>

        </tr>
   
<?php
        }
        else{
            echo "w tej sali nie jest zarejestrowany żaden sprzęt ";
        }
    


    foreach ($wyn as $key => $value) {
        ?>
        <tr>
            <td><?=$value['sala_nazwa'] ?></td>
            <td><?=$value['sprzet_nazwa'] ?></td>
            <td><?=$value['ilosc'] ?></td>

        </tr>
        <?php
    }
?>
 </table>
    <?php
}
    ?>
</div>




<div class="raporty">
<?php
$sale = $conn->query("SELECT  id,nazwa from sala");


// foreach ($sale as $key => $value) {
//     echo "<h2>". $value['nazwa']."</h2>";
    ?>
    <h1>ilość sprzetu ogólnie </h1>
    <table>
        <tr>
     
            <td>nazwa</td>
            <td>ilosc</td>

        </tr>
   
<?php
    foreach ($conn->query("SELECT gdzie.id as id, sprzet_id,sala_id,rodzaj.nazwa as sprzet_nazwa,sala.nazwa
     as sala_nazwa,sum(ilosc) as ilosc FROM `gdzie` join rodzaj on rodzaj.id =sprzet_id join sala on sala.id = sala_id group by sprzet_id; ") as $key => $value) {
        ?>
        <tr>
            <td><?=$value['sprzet_nazwa'] ?></td>
            <td><?=$value['ilosc'] ?></td>
          

        </tr>
        <?php
    }
?>
 </table>
    <?php
    // }
    ?>
</div>



</div>
