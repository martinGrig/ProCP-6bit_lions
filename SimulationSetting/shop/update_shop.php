<?php
include 'dbconnect.php';

$OldName = $_POST['OldName'];
$Name = $_POST['Name'];
$AverageSpending = $_POST['AverageSpending'];
$BusyHours = $_POST['BusyHours'];
$Category = $_POST['Category'];
$stmt = $dblink->prepare("UPDATE shop SET Name = ?, AverageSpending = ?, BusyHours = ?, Category = ? WHERE Name = ?");
$stmt->bind_param("sdsss", $Name, $AverageSpending, $BusyHours, $Category, $OldName);
$stmt->execute();
$stmt->close();
$dblink->close();

?>