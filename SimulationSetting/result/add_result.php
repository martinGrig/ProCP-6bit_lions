<?php
include 'dbconnect.php';

$sql = "INSERT INTO result (TotalIncome, TotalVisitors, Duration) VALUES (?,?,?);";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("dis", $_POST['TotalIncome'], $_POST['TotalVisitors'], $_POST['Duration']);
$stmt->execute();

$result = $dblink->query("SELECT LAST_INSERT_ID();");
$row = $result->fetch_assoc();
foreach($row as $key=>$value)
$resultID = $value;

$stmt->close();
$dblink->close();

//Print array in JSON format
echo $resultID;
header('Content-Type: application/json');
?>