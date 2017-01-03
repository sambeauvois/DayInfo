<?php

$easterdate = easter_date();

$array = array(
	"Nouvel an" =>  mktime(0, 0, 0, 1, 1, date("Y")),
    "Paques" => $easterdate,
    "Lundi de paques" => strtotime("+1 day", $easterdate),
	"Ascension" => strtotime("+39 days", $easterdate),
	"Lundi de Pentecote" => strtotime("+50 days", $easterdate),
	"Fête du travail" =>  mktime(0, 0, 0, 5, 1, date("Y")),
	"Fête nationale" =>  mktime(0, 0, 0, 7, 21, date("Y")),
	"Fête nationale" =>  mktime(0, 0, 0, 8, 15, date("Y")),
	"Assomption" =>  mktime(0, 0, 0, 5, 1, date("Y")),
	"Toussaint" =>  mktime(0, 0, 0, 11, 1, date("Y")),
	"Armistice" =>  mktime(0, 0, 0, 11, 11, date("Y")),
	"Noel" =>  mktime(0, 0, 0, 12, 25, date("Y")),
);

foreach ($array as $i => $value) {
	echo "<br/>" .$i . " : " . date("M-d-Y",$array[$i]);
}
