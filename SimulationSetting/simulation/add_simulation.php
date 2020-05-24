<?php
include 'dbconnect.php';

$sql = "INSERT INTO simulation (ID, StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales) VALUES (?,?,?,?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("isssssd", $_POST['ID'], $_POST['StartTime'], $_POST['EndTime'], $_POST['Weather'], $_POST['Holiday'], $_POST['DayOfTheWeek'], $_POST['Sales']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>