
<form action ="" method ="GET">
<select name ="uzycie">
<option value ="(0,1)" <?php if ($_GET['uzycie'] == "(0,1)") echo "selected"; ?>> wszystkie</option>
<option value ="(1)" <?php if ($_GET['uzycie'] == "(1)") echo "selected"; ?>> nowe</option>
<option value ="(0)" <?php if ($_GET['uzycie'] == "(0)") echo "selected"; ?>> uzywane</option>



</select>
<input type="submit"> 
</form>
<a href="index.php">index </a>
<?php



$conn = new mysqli("localhost","root","","buty");

$sql = "";
if($_GET!=null){
    $sql = "SELECT * from buty where nowe in ". $_GET['uzycie'];
}
else{
    $sql = "SELECT * FROM buty";
}
var_dump($sql);
$x = $conn->query($sql);
// $dane =$x->fetch_all();
// var_dump($x->fetch_all());
// var_dump($x);
// var_dump($x->fetch_assoc());
echo "<table>";
echo "<tr>";
echo "<td>id</td>";
echo "<td>nazwa</td>";
echo "<td>cena</td>";
echo "<td>kiedy</td>";
echo "<td>nowe</td>";
echo "</tr>";
foreach ($x as $key => $value) {
    echo "<tr>";
    echo "<td>".$value["id"]."</td>";
    echo "<td>".$value["nazwa"]."</td>";
    echo "<td>".$value["cena"]."</td>";
    echo "<td>".$value["kiedy"]."</td>";
    if($value['nowe'] =="0"){
        echo  "<td> nie </td>";
    }
    else if($value['nowe'] == "1"){
    echo "<td>tak</td>";
    }
    else{
        echo "<td>złe dane</td>"; 
    }
    echo "</tr>";
}
echo"</table>";


// echo "   xx" .$nowe . "xx       ";
$conn->close();
?>
