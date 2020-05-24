<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$TotalIncome = $_POST['TotalIncome'];
$TotalVisitors = $_POST['TotalVisitors'];
$Duration = $_POST['Duration'];
$stmt = $dblink->prepare("UPDATE result SET TotalIncome = ?, TotalVisitors =?, Duration = ? WHERE ID = ?");
$stmt->bind_param("disi", $TotalIncome, $TotalVisitors, $Duration, $ID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>