<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$StartTime = $_POST['StartTime'];
$EndTime = $_POST['EndTime'];
$Weather = $_POST['Weather'];
$Holiday = $_POST['Holiday'];
$DayOfTheWeek = $_POST['DayOfTheWeek'];
$Sales = $_POST['Sales'];
$stmt = $dblink->prepare("UPDATE simulation SET StartTime = ?, EndTime =?, Weather = ?, Holiday = ?, DayOfTheWeek = ?, Sales = ? WHERE ID = ?");
$stmt->bind_param("sssssdi", $StartTime, $EndTime, $Weather, $Holiday, $DayOfTheWeek, $Sales, $ID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>