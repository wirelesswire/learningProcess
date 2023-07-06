
<pre>

<style>
    td{
        border: 1px solid black;
    }
    table{
        border-collapse:collapse;
    }
</style>
<?php


$conn = new mysqli("localhost","root","","skup_rolny");
$xd =[];
$sqlnazwy = "SELECT distinct year(kiedy)as rok from op group by rok ";
$tab = $conn->query($sqlnazwy);
$tab2 = $conn->query("SELECT distinct nazwa from zboze ");
foreach ($tab as $key => $value) {
    $xd[$value['rok']] =[];
}
// var_dump($xd);
$sql = "SELECT zboze.nazwa as nazwa,sum(ile) as ile,year(op.kiedy) as rok,month(kiedy) as miesiac,rodzaj FROM `op` join zboze on zboze_id = zboze.id_zboze  GROUP by zboze.nazwa , rok,miesiac,rodzaj;";
foreach ($conn->query($sql) as $key => $value) {
    if(!isset($xd[$value['rok']][$value['miesiac']][$value['nazwa']][$value['rodzaj']]  )){
        $xd[$value['rok']][$value['miesiac']][$value['nazwa']][$value['rodzaj']] =$value['ile'];
    }

}
// print_r($xd);

foreach ($tab as $key => $value) {


    // var_dump($value['rok']);
    ?>
    <h1><?= $value['rok']?></h1>
    <table>
    <?php
    
    echo "<tr>";
    echo "<td> miesiac "."  </td>";
    foreach ($tab2  as $key4 => $x) {
        # code...
        
        echo "<td>".$x['nazwa']  ." zakup </td>";
        echo "<td>".$x['nazwa']  ." sprzedaż </td>";
    }
    foreach ($xd[$value['rok']] as $key1 => $value1) {
        ?> 
        
        <?php
       
        
        echo "</tr>";

        echo "<tr>";
        echo "<td>".$key1 ."</td>";
        foreach ($tab2 as $key2 => $value2) {
            
            // echo "<td>".$value2['nazwa']."</td>";
            // foreach ($tab2  as $key4 => $xdas) {
            //     # code...
            //     echo "<td>".$x['nazwa']  ." zakup <td>";
            //     echo "<td>".$x['nazwa']  ." sprzedaż <td>";
            // }
            echo "<td>".$value1[$value2['nazwa']]['zakup']."</td>";
            echo "<td>".$value1[$value2['nazwa']]['sprzedaż']."</td>";
            // echo "nazwa \n";
            // var_dump($value2['nazwa']);
            // var_dump($value1[$value2['nazwa']]);
        }
        echo "</tr>";

    }
        ?>
    </table>

<?php
    
    
}






