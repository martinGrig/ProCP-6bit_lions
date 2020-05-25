<?php
include 'dbconnect.php';

$sql = "INSERT INTO simulation (Name, StartTime, EndTime, Weather, Holiday, DayOfTheWeek, Sales) VALUES (?,?,?,?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("ssssssd", $_POST['Name'], $_POST['StartTime'], $_POST['EndTime'], $_POST['Weather'], $_POST['Holiday'], $_POST['DayOfTheWeek'], $_POST['Sales']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>