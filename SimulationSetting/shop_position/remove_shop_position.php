<?php
include 'dbconnect.php';

$SimulationID = $_POST['SimulationID'];
$ShopID = $_POST['ShopID'];
$stmt = $dblink->prepare("DELETE FROM shop_position WHERE SimulationID = ? AND ShopID = ?");
$stmt->bind_param("ii", $SimulationID, $ShopID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>