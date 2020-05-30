<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop_result (ResultID, ShopName, Income, Visitors) VALUES (?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("isdi", $_POST['ResultID'], $_POST['ShopName'], $_POST['Income'], $_POST['Visitors']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>