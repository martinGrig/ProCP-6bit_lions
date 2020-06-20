<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table
  $result = $dblink->query("SELECT * FROM shop");

//Initialize array variable
  $shops = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$shops[]=$row;
  }

//Print array in JSON format
 echo json_encode($shops);
 header('Content-Type: application/json');
?>
