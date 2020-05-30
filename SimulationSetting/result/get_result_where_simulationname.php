<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table

$SimulationName = $_POST['SimulationName'];

  $result = $dblink->query("SELECT ID FROM result WHERE SimulationName = '$SimulationName'");
//Initialize array variable
  $result = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$result[]=$row;
  }

//Print array in JSON format
 echo json_encode($result);
 header('Content-Type: application/json');
?>