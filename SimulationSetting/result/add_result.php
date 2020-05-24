<?php
include 'dbconnect.php';

$sql = "INSERT INTO result (ID, TotalIncome, TotalVisitors, Duration) VALUES (?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("idis", $_POST['ID'], $_POST['TotalIncome'], $_POST['TotalVisitors'], $_POST['Duration']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>