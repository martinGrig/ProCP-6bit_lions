<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table

$ResultID = $_POST['ResultID'];
  $result = $dblink->query("SELECT * FROM shop_result WHERE $ResultID");
//Initialize array variable
  $shop_result = array();

//Fetch into associative array
  while ( $row = $result->fetch_assoc())  {
	$shop_result[]=$row;
  }

//Print array in JSON format
 echo json_encode($shop_result);
 header('Content-Type: application/json');
?>