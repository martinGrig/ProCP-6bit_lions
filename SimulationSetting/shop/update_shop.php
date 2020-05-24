<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$Name = $_POST['Name'];
$Capacity = $_POST['Capacity'];
$Popularity = $_POST['Popularity'];
$PriceRange = $_POST['PriceRange'];
$BusyHours = $_POST['BusyHours'];
$Category = $_POST['Category'];
$stmt = $dblink->prepare("UPDATE shop SET Name = ?, Capacity =?, Popularity = ?, PriceRange = ?, BusyHours = ?, Category = ? WHERE ID = ?");
$stmt->bind_param("siddssi", $Name, $Capacity, $Popularity, $PriceRange, $BusyHours, $Category, $ID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>