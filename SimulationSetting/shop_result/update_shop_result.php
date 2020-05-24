<?php
include 'dbconnect.php';

$ResultID = $_POST['ResultID'];
$ShopID = $_POST['ShopID'];
$Income = $_POST['Income'];
$Visitors = $_POST['Visitors'];
$stmt = $dblink->prepare("UPDATE shop_result SET Income =?, Visitors = ? WHERE ResultID = ? AND ShopID = ?");
$stmt->bind_param("diii", $Income, $Visitors, $ResultID, $ShopID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>