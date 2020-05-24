<?php
include 'dbconnect.php';

$SimulationID = $_POST['SimulationID'];
$ShopID = $_POST['ShopID'];
$PositionID = $_POST['PositionID'];
$stmt = $dblink->prepare("UPDATE shop_position SET PositionID = ? WHERE SimulationID = ? AND ShopID = ?");
$stmt->bind_param("iii", $PositionID, $SimulationID, $ShopID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>