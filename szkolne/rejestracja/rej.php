<?php
$conn =new mysqli("localhost","root","","rejestracja");
// var_dump($_POST);
$corobisz =$_POST['sub'] ?? "cosimnnnego";
if($corobisz=="dodajTermin"){
    $data =$_POST['data'];
    $sql = "INSERT INTO `terminy` (`id`, `iin`, `email`, `telefon`, `termin`, `wolne`) VALUES (NULL, '', '', 0, '${data}', 1) ";
    var_dump($sql);
    $conn->query($sql);
    header("location:rej.php");
}
else if($corobisz=="normal"){
    $imie=$_POST['imie'];
    $email =$_POST['email'];
    $telefon = $_POST['telefon'];
    $termin = $_POST['termin'];
    if($termin !="niema"){
    $sql = "UPDATE `terminy` SET `iin` = '${imie}', `email` = '${email}', `telefon` = '${telefon}' ,`wolne`= 0 WHERE `terminy`.`termin` = '${termin}' ";
    var_dump($sql);
    $conn->query($sql);
    header("location:rej.php");}
    else{
        echo "nie ma terminow";
    }
}
?>
<div id="div"></div>
<form method="POST" action="rej.php">
<input id="inputimie" name="imie" type="text">
<input id="inputemail" name="email" type="email">
<input id="inputtelefon" name="telefon" type="telefon">
<select name="termin" >
<?php
$wys =false;
foreach ($conn->query("select termin from terminy where wolne =1") as $key => $value) {
    echo "<option>".$value['termin']."</option>";
    $wys=true;
}
if(!$wys){
    echo "<option value='niema'> nie ma wolnych terminów </option>";
}


?>


</select>
<input id="submitbtn" name="sub" value="normal" type="submit">
</form>

<form method="POST" action="rej.php">
<input type="datetime-local" name="data">
<input name="sub" type="submit" value="dodajTermin">
</form>

<script src="js.js"></script>