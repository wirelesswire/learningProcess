<pre>
<?php

$tab = [];
foreach ((new mysqli("localhost","root","","skup_rolny"))->query("SELECT year(kiedy) as rok ,sum(ile) as ile ,month(kiedy)as miesiac FROM `op` group by year(kiedy),month(kiedy)  
ORDER BY `ile`  DESC;") as $key => $value) {
    if(!isset($tab[$value['rok']])){
        $tab[$value['rok']] = [$value['miesiac'],$value['ile']];
    }
}
ksort($tab);
foreach ($tab as $key => $value) {
    echo "najwiecej w roku " . $key. "  bylo skupow  w miesiacu :" .$value[0]."(".$value[1].")"."\n";
}

