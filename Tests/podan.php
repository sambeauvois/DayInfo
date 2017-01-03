<?php

$easterdate = easter_date();

$hollidays = array(
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

foreach ($hollidays as $i => $value) {
	echo "<br/>" .$i . " : " . date("M-d-Y",$hollidays[$i]);
}


echo "<hr/>";
$month = date("m",$easterdate);
echo "<br/>". $month;

$day = date("D",$easterdate);
echo "<br/>". $day;

echo "<table>";
echo "<thead>";
echo "<tr>";
echo "<th>";
echo "</th>";
echo "<th>Matin";
echo "</th>";
echo "<th>Après-midi";
echo "</th>";
echo "</tr>";
echo "</thead>";
echo "<tbody>";

echo "<tr>";
echo "<th>Lundi";
echo "</th>";
echo "<td>Fermé";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";

echo "<tr>";
echo "<th>Mardi";
echo "</th>";
echo "<td>10h00 - 13h00";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";

echo "<tr>";
echo "<th>Mercredi";
echo "</th>";
echo "<td>10h00 - 13h00";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";

echo "<tr>";
echo "<th>Jeudi";
echo "</th>";
echo "<td>10h00 - 13h00";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";


echo "<tr>";
echo "<th>Vendredi";
echo "</th>";
echo "<td>10h00 - 13h00";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";

echo "<tr>";
echo "<th>Samedi";
echo "</th>";
echo "<td>10h00 - 13h00";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";

echo "<tr>";
echo "<th>Dimanche";
echo "</th>";
echo "<td>";
echo "</td>";
echo "<td>14h00 - 18h00";
echo "</td>";
echo "</tr>";

echo "</tbody>";
echo "</table>";



//echo  "Paques ". date("M-d-Y",$easterdate) . "<br />";

//echo  "Lundi de paques ". date("M-d-Y",strtotime("+1 day", $easterdate)) .  "<br />";
