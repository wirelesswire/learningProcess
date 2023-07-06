<?php

$conn = new mysqli("localhost","root","","skup_rolny");
echo "<h1>indywidualni</h1>";
$x = $conn->query("SELECT * FROM klient where indywidualny  =1 ");
 
echo "<table>";
echo "<tr>";
echo "<td>id</td>";
echo "<td>imie</td>";
echo "<td>nazwisko</td>";
echo "<td>adres</td>";
echo "<td>indywidualny</td>";

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

    echo "</tr>";
}
echo"</table>";


$x = $conn->query("SELECT * FROM klient where indywidualny  =0 ");
echo "<h1>firmy</h1>";
echo "<table>";
echo "<tr>";
echo "<td>id</td>";
echo "<td>imie</td>";
echo "<td>nazwisko</td>";
echo "<td>adres</td>";
echo "<td>indywidualny</td>";

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

    echo "</tr>";
}
echo"</table>";

?>

