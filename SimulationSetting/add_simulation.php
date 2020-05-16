<?php
include 'dbconnect.php';

$StartTime = $_POST['StartTime'];
$EndTime = $_POST['EndTime'];
$Weather = $_POST['Weather'];
$Holiday = $_POST['Holiday'];
$DayOfTheWeek = $_POST['DayOfTheWeek'];
$stmt = $dbconnection->prepare("INSERT INTO simulation (StartTime, EndTime, Weather, Holiday, DayOfTheWeek) VALUES (?, ?, ?, ?, ?);");
$stmt->bind_param("si", $StartTime, $EndTime, $Weather, $Holiday, $DayOfTheWeek);
$stmt->execute();



$stmt->close();
$dbconnection->close();

?>