<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$PositionID = $_POST['PositionID'];
$Name = $_POST['Name'];
$Capacity = $_POST['Capacity'];
$Popularity = $_POST['Popularity'];
$PriceRange = $_POST['PriceRange'];
$BusyHours = $_POST['BusyHours'];
$Category = $_POST['Category'];
$stmt = $dbconnection->prepare("INSERT INTO shop (ID, PositionID, Name, Capacity, Popularity, PriceRange, BusyHours, Category) VALUES (?, ?, ?, ?, ?, ?, ?, ?);");
$stmt->bind_param("iisiddss", $ID, $PositionID, $Name, $Capacity, $Popularity, $PriceRange, $BusyHours, $Category);
$stmt->execute();



$stmt->close();
$dbconnection->close();

?>