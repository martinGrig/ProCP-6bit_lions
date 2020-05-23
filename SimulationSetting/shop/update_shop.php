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
$stmt = $dbconnection->prepare("UPDATE shop SET Name = '".$Name."', Capacity ='". $Capacity ."', Popularity = '". $Popularity .", PriceRange = '". $PriceRange .", BusyHours = '". $BusyHours .", Category = '". $Category ."' WHERE ID = ".$_GET['ID'] VALUES (?, ?, ?, ?, ?, ?, ?, ?);");
    
$stmt->bind_param("iisiddss", $ID, $PositionID, $Name, $Capacity, $Popularity, $PriceRange, $BusyHours, $Category);
$stmt->execute();

$stmt->close();
$dbconnection->close();

?>