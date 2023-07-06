<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        .wrap{
            display:flex;
            width:100%;
        }
        .lista{
            flex:1;
        }
        p{
            margin: 10 0 ;
            text-align:center;
        }
        .green{
            background-color:green;
            color:#222;
        }
        .red{
            background-color:red;
            color:#222;
        }
        .blue{
            background-color:blue;
            color:#888 ;
        }
        .yellow{
            background-color:yellow;
            /* color:white; */
        }
        a{
            text-decoration:none;
            color:inherit;
            font-style:italic;
        }
        

        </style>
</head>
<body>
    
</body>
</html>


<?php
$tabelastan =[
"szkoła"=>"green",
"domowe"=>"red",
"hobby"=>"blue",
"inne"=>"yellow"

];
$conn = new mysqli("localhost","root","","todoapp");
$gdzie =$conn->query("SELECT * FROM gdzie");
$stan = $conn->query("SELECT * FROM stan");
$opis_val=$_GET['opis'] ?? "";
$gdzie_val = $_GET['gdzie']??1;
$stan_val =$_GET['stan']??1;
$data_val = $_GET['data'] ?? date("d-m-Y");
?>
<form action="dodaj.php" method="GET">
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
<input type="date" name="data" value = <?=$data_val ?>>
<input type="submit"  name="dodaj">
</form>
<?php

$sqldowyswietlenia = "SELECT wszystkie.id as id, opis,gdzie.nazwa as gdzie,stan.nazwa stan,data FROM `wszystkie` join gdzie on gdzie_id = gdzie.id JOIN stan on stan_id =stan.id ";
$wynik =$conn->query($sqldowyswietlenia);
// var_dump($wynik);
?>

<div class="wrap">
<div class ="lista">
<p>planowane</p>
    <ul>
<?php
foreach ($wynik as $key => $value) {
  
    if($value['stan']=="planowane"){
        echo "<li class=\"".$tabelastan[$value['gdzie']]."\">". $value['opis'] ." ". $value['gdzie'] ." ". $value['stan'] ." ". $value['data']."<a href='update.php?id=".$value['id']."'> edytuj</a>"."</li>";
    }
}
?>
</ul>
</div>



<div class ="lista">
<p>rozpoczete</p>
    <ul>
<?php
foreach ($wynik as $key => $value) {
  
    if($value['stan']=="rozpoczęte"){
        echo "<li class=\"".$tabelastan[$value['gdzie']]."\">". $value['opis'] ." ". $value['gdzie'] ." ". $value['stan'] ." ". $value['data']."<a href='update.php?id=".$value['id']."'> edytuj</a>"."</li>";
    }
}
?>
</ul>
</div>
</div>


<div class="wrap">
<div class ="lista">
<p>zakończone</p>
    <ul>
<?php
foreach ($wynik as $key => $value) {
  
    if($value['stan']=="zakończone"){
        echo "<li class=\"".$tabelastan[$value['gdzie']]."\">".$value['opis'] ." ". $value['gdzie'] ." ". $value['stan'] ." ". $value['data']."<a href='update.php?id=".$value['id']."'> edytuj</a>"."</li>";
    }
}
?>
</ul>
</div>




<div class ="lista">
<p>rezygnacja</p>
    <ul>
<?php
foreach ($wynik as $key => $value) {
  
    if($value['stan']=="rezygnacja"){
        echo "<li class=\"".$tabelastan[$value['gdzie']]."\">". $value['opis'] ." ". $value['gdzie'] ." ". $value['stan'] ." ". $value['data']."<a href='update.php?id=".$value['id']."'> edytuj</a>"."</li>";
    }
}
?>
</ul>
</div>
</div>