<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop_position (SimulationID, ShopID, PositionID) VALUES (?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("iii", $_POST['SimulationID'], $_POST['ShopID'], $_POST['PositionID']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>