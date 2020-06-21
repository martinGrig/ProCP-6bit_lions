<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table
  $result = $dblink->query("SELECT * FROM result");

//Initialize array variable
  $results = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$results[]=$row;
  }

//Print array in JSON format
 echo json_encode($results);
 header('Content-Type: application/json');
?>