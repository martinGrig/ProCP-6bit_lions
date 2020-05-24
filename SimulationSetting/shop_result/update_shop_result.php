<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$ShopID = $_POST['ShopID'];
$Income = $_POST['Income'];
$Visits = $_POST['Visits'];
$TotalIncome = $_POST['TotalIncome'];
$Duration = $_POST['Duration'];
$stmt = $dblink->prepare("UPDATE shop_result SET ShopID = ?, Income =?, Visits = ?, TotalIncome = ?, Duration = ? WHERE ID = ?");
$stmt->bind_param("ididsi", $ShopID, $Income, $Visits, $TotalIncome, $Duration, $ID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>