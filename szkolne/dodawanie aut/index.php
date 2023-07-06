<?php
// var_dump($_POST);
// $conn = new mysqli("localhost","root","","buty");

// if($_POST!=null){
// $nazwa = $_POST['nazwa'];
// $cena  = $_POST['cena'];
// $nowe = 0;
// if( isset( $_POST['nowe'])){
// $nowe =1;
// }
// $isoktoputtodb =true;
// if(!$nazwa){
//     echo "nie podałeś nazwy </br>";
//     $isoktoputtodb =false;
// }
// if(!$cena ){
//     echo " nie podałeś ceny</br>";
//     $isoktoputtodb =false;
// }
// if( $isoktoputtodb){
// $kiedy = date("Y-m-d H:i:s");

// // $sql = "INSERT into buty values(null,`$nazwa`,`$kiedy`,`$cena`,`$nowe`)";
// $sql ="INSERT INTO `buty` (`id`, `nazwa`, `kiedy`, `cena`, `nowe`) VALUES (null,'${nazwa}','{$kiedy}','${cena}','{$nowe}')";
// var_dump($sql);
// $conn->query($sql);
//     header("location:index.php");
//     // exit;
// }
// }
?>
<form action="dodaj.php" method="POST">

<input type="text" name="nazwa">
<input type="number" name="cena" id="">
<input type="checkbox" name="nowe" id="" value ="1"> czy są nowe 
<input type="submit" value="submit">
<a href="lista.php"> lista</a>
</form>


<?php



//     $x = $conn->query("SELECT * FROM buty");
//     // $dane =$x->fetch_all();
//     var_dump($x->fetch_all());
//     var_dump($x);
//     var_dump($x->fetch_assoc());
//     echo "<table>";
//     echo "<tr>";
//     echo "<td>id</td>";
//     echo "<td>nazwa</td>";
//     echo "<td>cena</td>";
//     echo "<td>kiedy</td>";
//     echo "<td>nowe</td>";
//     echo "</tr>";
//     foreach ($x as $key => $value) {
//         echo "<tr>";
//         echo "<td>".$value["id"]."</td>";
//         echo "<td>".$value["nazwa"]."</td>";
//         echo "<td>".$value["cena"]."</td>";
//         echo "<td>".$value["kiedy"]."</td>";
//         if($value['nowe'] =="0"){
//             echo  "<td> nie </td>";
//         }
//         else if($value['nowe'] == "1"){
//         echo "<td>tak</td>";
//         }
//         else{
//             echo "<td>złe dane</td>"; 
//         }
//         echo "</tr>";
//     }
//     echo"</table>";


// // echo "   xx" .$nowe . "xx       ";
// $conn->close();
?>
