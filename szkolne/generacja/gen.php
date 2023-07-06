<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <style>
        #wrap{
            display:flex;
        }
        .div{
            flex:1;
        }

        </style>
</head>
<body>
    
</body>
</html>

<?php
$dane = fopen("dane.txt","r");

$tab = [];
$dne =fgets($dane);
while($dne){
    $tab[] = explode(";",$dne);
    $dne = fgets($dane);


}


?>
<div id="wrap">
<div class="div">
<ol>
<?php
foreach ($tab as $key => $value) {
    ?>
        <li><a href="gen.php?id=<?=$key?>"> <?=$value[0]?></a></li>
    <?php
}
?>
</ol>

</div>

<div class="div">
<?php
$iddowys = $_GET['id']?? "";
if($iddowys !=""){
    $zmienna = "
    <p>Zaświadczenie</p>
    <p> {$tab[$iddowys][0]} </p>
    <p>Ukończył kurs:  {$tab[$iddowys][1]}</p>
    <p>z oceną  {$tab[$iddowys][2]}</p>";
    echo $zmienna;
    fwrite(fopen("{$tab[$iddowys][0]}".".html","w"),$zmienna);
   
}
?>
</div>
</div>