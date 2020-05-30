<?php
include 'dbconnect.php';

$SimulationName = $_POST['SimulationName'];
$ShopName = $_POST['ShopName'];
$PositionID = $_POST['PositionID'];
$stmt = $dblink->prepare("UPDATE shop_position SET PositionID = ? WHERE SimulationName = ? AND ShopName = ?");
$stmt->bind_param("iss", $PositionID, $SimulationName, $ShopName);
$stmt->execute();
$stmt->close();
$dblink->close();

?>