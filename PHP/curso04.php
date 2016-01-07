<?php


//definiendo constantes , constante saludo con valor "Hola, como estas?"
define("saludo","Hola, como estas?");
define("numero",20);


echo "<br/><b> Imprimiendo constantes </b> <br/>";

echo saludo;
echo numero;

echo "<br/><br/> <b> Concatenando </b> <br/>";

//concatenacion con punto (en ves de +)

echo saludo." tengo ".numero." anios";


?>