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
$stmt = $dbconnection->prepare("UPDATE shop SET Name = ?, Capacity =?,
 Popularity = ?, PriceRange = ?, BusyHours = ?
, Category = ? WHERE ID = ? VALUES (?, ?, ?, ?, ?, ?, ?, ?)");
    
$stmt->bind_param("isiddssi", $PositionID, $Name, $Capacity, $Popularity, $PriceRange, $BusyHours, $Category, $ID);
$stmt->execute();

$stmt->close();
$dbconnection->close();

?>