<?php

//arrays predefinidos

$array = array("elemento1",2,"element 3");

echo "<br/> <b> Arreglos predifinidos </b> <br/>";

echo "Elemento 1 : ".$array[0]."<br/>";
echo "Elemento 2 : ".$array[1]."<br/>";
echo "Elemento 3 : ".$array[2]."<br/>";

//arays asociativos o personalizados

echo "<br/> <b> Arreglos asociativos </b> <br/>";

//claves personalizadas para cada elemento
$asociativo = array("clave1" => "elemento1","clave2" => 2,"clave3" => "element 3");

echo "Elemento 1 : ".$asociativo["clave1"]."<br/>";
echo "Elemento 2 : ".$asociativo["clave2"]."<br/>";
echo "Elemento 3 : ".$asociativo["clave3"]."<br/>";

?>