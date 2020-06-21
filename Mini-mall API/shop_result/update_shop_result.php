<?php
include 'dbconnect.php';

$ResultID = $_POST['ResultID'];
$ShopName = $_POST['ShopName'];
$Income = $_POST['Income'];
$Visitors = $_POST['Visitors'];
$stmt = $dblink->prepare("UPDATE shop_result SET Income =?, Visitors = ? WHERE ResultID = ? AND ShopName = ?");
$stmt->bind_param("diis", $Income, $Visitors, $ResultID, $ShopName);
$stmt->execute();
$stmt->close();
$dblink->close();

?>