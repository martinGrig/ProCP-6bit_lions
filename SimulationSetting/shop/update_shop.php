<?php
include 'dbconnect.php';

$Name = $_POST['Name'];
$Popularity = $_POST['Popularity'];
$PriceRange = $_POST['PriceRange'];
$BusyHours = $_POST['BusyHours'];
$Category = $_POST['Category'];
$stmt = $dblink->prepare("UPDATE shop SET Popularity = ?, PriceRange = ?, BusyHours = ?, Category = ? WHERE Name = ?");
$stmt->bind_param("ddsss", $Popularity, $PriceRange, $BusyHours, $Category, $Name);
$stmt->execute();
$stmt->close();
$dblink->close();

?>