<?php
include 'dbconnect.php';
//Fetch 3 rows from actor table

$Weather = $_POST['Weather'];
$Holiday = $_POST['Holiday'];
$DayOfTheWeek = $_POST['DayOfTheWeek'];
$Sales = $_POST['Sales'];
$Duration = $_POST['Duration'];
  $result = $dblink->query(
    "SELECT ResultID, PositionID, r.ShopName, Income 
    FROM shop_result r left join result rm on r.ResultID = rm.ID join shop_position p on r.ShopName=p.ShopName 
      AND rm.SimulationName=p.SimulationName 
    WHERE r.ResultID IN ( 
      SELECT ID 
      FROM result 
      WHERE SimulationName IN ( 
        SELECT Name 
        FROM simulation 
        WHERE Weather = '$Weather' 
          AND Holiday = '$Holiday' 
          AND DayOfTheWeek = '$DayOfTheWeek' 
          AND Sales = '$Sales')) 
    ORDER BY PositionID");
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