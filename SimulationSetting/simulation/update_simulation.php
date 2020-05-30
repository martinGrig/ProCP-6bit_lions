<?php
include 'dbconnect.php';

$Name = $_POST['Name'];
$StartTime = $_POST['StartTime'];
$EndTime = $_POST['EndTime'];
$Weather = $_POST['Weather'];
$Holiday = $_POST['Holiday'];
$DayOfTheWeek = $_POST['DayOfTheWeek'];
$Sales = $_POST['Sales'];
$stmt = $dblink->prepare("UPDATE simulation SET StartTime = ?, EndTime =?, Weather = ?, Holiday = ?, DayOfTheWeek = ?, Sales = ? WHERE Name = ?");
$stmt->bind_param("sssssss", $StartTime, $EndTime, $Weather, $Holiday, $DayOfTheWeek, $Sales, $Name);
$stmt->execute();
$stmt->close();
$dblink->close();

?>