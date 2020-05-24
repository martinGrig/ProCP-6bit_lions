<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table
  $result = $dblink->query("SELECT * FROM simulation");

//Initialize array variable
  $simulations = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$simulations[]=$row;
  }

//Print array in JSON format
 echo json_encode($simulations);
 header('Content-Type: application/json');
?>