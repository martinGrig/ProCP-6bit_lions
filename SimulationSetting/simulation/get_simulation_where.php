<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table

$StartTime = $_POST['StartTime'];
$EndTime = $_POST['EndTime'];
$Weather = $_POST['Weather'];
$Holiday = $_POST['Holiday'];
$DayOfTheWeek = $_POST['DayOfTheWeek'];
$Sales = $_POST['Sales'];

  $result = $dblink->query("SELECT ID FROM simulation WHERE StartTime = '$StartTime' AND EndTime = '$EndTime' AND Weather = '$Weather' AND Holiday = '$Holiday' AND DayOfTheWeek = '$DayOfTheWeek' AND Sales = '$Sales'");
//Initialize array variable
  $simulation = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$simulation[]=$row;
  }

//Print array in JSON format
 echo json_encode($simulation);
 header('Content-Type: application/json');
?>