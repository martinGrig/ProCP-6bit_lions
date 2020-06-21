<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$SimulationName = $_POST['SimulationName'];
$TotalIncome = $_POST['TotalIncome'];
$TotalVisitors = $_POST['TotalVisitors'];
$Duration = $_POST['Duration'];
$stmt = $dblink->prepare("UPDATE result SET SimulationName = ?, TotalIncome = ?, TotalVisitors =?, Duration = ? WHERE ID = ?");
$stmt->bind_param("sdisi", $SimulationName $TotalIncome, $TotalVisitors, $Duration, $ID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>