<?php
include 'dbconnect.php';

$StartTime = $_POST['StartTime'];
$EndTime = $_POST['EndTime'];
$Weather = $_POST['Weather'];
$Holiday = $_POST['Holiday'];
$DayOfTheWeek = $_POST['DayOfTheWeek'];
$Sales = $_POST['Sales'];
$stmt = $dbconnection->prepare("INSERT INTO simulation (StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales) VALUES (?, ?, ?, ?, ?, ?);");
$stmt->bind_param("sssssd", $StartTime, $EndTime, $Weather, $Holiday, $DayOfTheWeek, $Sales);
$stmt->execute();



$stmt->close();
$dbconnection->close();

?>