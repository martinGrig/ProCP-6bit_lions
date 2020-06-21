<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table

$SimulationName = $_POST['SimulationName'];
  $result = $dblink->query("SELECT * FROM shop_position WHERE SimulationName = '$SimulationName'");
//Initialize array variable
  $shop_position = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$shop_position[]=$row;
  }

//Print array in JSON format
 echo json_encode($shop_position);
 header('Content-Type: application/json');
?>