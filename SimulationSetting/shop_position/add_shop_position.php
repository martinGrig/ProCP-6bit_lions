<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop_position (SimulationName, ShopName, PositionID) VALUES (?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("ssi", $_POST['SimulationName'], $_POST['ShopName'], $_POST['PositionID']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>