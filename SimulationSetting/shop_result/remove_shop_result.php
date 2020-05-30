<?php
include 'dbconnect.php';

$ResultID = $_POST['ResultID'];
$ShopName = $_POST['ShopName'];
$stmt = $dblink->prepare("DELETE FROM shop_result WHERE ResultID = ? AND ShopName = ?");
$stmt->bind_param("is", $ResultID, $ShopName);
$stmt->execute();
$stmt->close();
$dblink->close();

?>