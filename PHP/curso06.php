
<?php

/*

Operadores Aritmeticos:

+,-,/,%

*/

$adicion = 4+4;
$multi= $adicion *3;

echo "<br/> <b> Operadores aritmeticos </b> <br/>";

echo $adicion;
echo "<br/>";
echo $multi;

echo "<br/> <b> Operadores de cadena </b> <br/>";
//Operadores de cadena con el punto (.)

$tengo = "yo ";
$tengo .= "tengo ";
$tengo .= "20 anios";

echo $tengo;

//Operadores de comparacion
/*
	Igual (==)
	Identico (===)
	>,<,!= o <>,>=,<=
*/

echo "<br/> <b> Operadores de comparacion </b> <br/>";

echo (6 >= 4);
echo "<br/>";
//no se imprimira
echo (5 == 11);


//Operador de control de errores
//con el @

echo "<br/> <b> Operadores de control de errores </b> <br/>";


echo "Hola";

 @define("");


 //Operadores de incremento
 //++,--, +=,-=,*=

 //si el ++ es antes primero incrementara despues hara el "echo"
 //si el ++ es despues primero hara el "echo" y despues incrementara

//----


 //Operadores de logica

 //&& o and , || o or, xor 
 

?>