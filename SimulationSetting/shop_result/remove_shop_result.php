<?php
include 'dbconnect.php';

$ResultID = $_POST['ResultID'];
$ShopID = $_POST['ShopID'];
$stmt = $dblink->prepare("DELETE FROM shop_result WHERE ResultID = ? AND ShopID = ?");
$stmt->bind_param("ii", $ID, $ShopID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>