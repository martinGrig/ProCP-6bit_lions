<?php

include 'dbconnect.php';
//Fetch 3 rows from actor table
  $result = $dblink->query("SELECT * FROM shop");

//Initialize array variable
  $dbdata = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$dbdata[]=$row;
  }

//Print array in JSON format
 echo json_encode($dbdata);
?>
