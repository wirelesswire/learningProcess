<?php
$conn = new mysqli("localhost","root","","skup_rolny");
$sprzedane = "SELECT zboze.nazwa,sum(ile) FROM `op` join zboze on zboze_id = zboze.id_zboze where rodzaj = \"sprzedaż\" GROUP by zboze.nazwa;";
$kupione = "SELECT zboze.nazwa,sum(ile) FROM `op` join zboze on zboze_id = zboze.id_zboze where rodzaj = \"zakup\" GROUP by zboze.nazwa; ";


?>
sprzedanie 
<table>

<?php
foreach ($conn->query($sprzedane) as $key => $value) {
    ?>
    <tr>
    <td><?=$value['nazwa']?> </td>
    <td><?=$value['sum(ile)']?> </td>
    </tr>
        <?php
}
?>
</table>


zakup 
<table>

<?php
foreach ($conn->query($kupione) as $key => $value) {
    ?>
    <tr>
    <td><?=$value['nazwa']?> </td>
    <td><?=$value['sum(ile)']?> </td>
    </tr>
        <?php
}
?>
</table>
<?php