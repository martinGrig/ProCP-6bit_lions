<?php
include 'dbconnect.php';

$sql = "INSERT INTO result (ID, SimulationName, TotalIncome, TotalVisitors, Duration) VALUES (?,?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("isdis", $_POST['ID'], $_POST['SimulationName'] $_POST['TotalIncome'], $_POST['TotalVisitors'], $_POST['Duration']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>