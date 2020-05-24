<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop_result (ResultID, ShopID, Income, Visitors) VALUES (?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("iidi", $_POST['ResultID'], $_POST['ShopID'], $_POST['Income'], $_POST['Visitors']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>