<?php
include 'dbconnect.php';

$SimulationName = $_POST['SimulationName'];
$ShopName = $_POST['ShopName'];
$stmt = $dblink->prepare("DELETE FROM shop_position WHERE SimulationName = ? AND ShopName = ?");
$stmt->bind_param("ss", $SimulationName, $ShopName);
$stmt->execute();
$stmt->close();
$dblink->close();

?>