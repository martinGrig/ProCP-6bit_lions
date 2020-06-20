<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop ( Name, AverageSpending, BusyHours, Category) VALUES (?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("sdss", $_POST['Name'], $_POST['AverageSpending'], $_POST['BusyHours'], $_POST['Category']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>