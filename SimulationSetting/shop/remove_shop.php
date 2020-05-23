<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$stmt = $dbconnection->prepare("DELETE FROM shop WHERE ID = ?);
$stmt->bind_param("i", $ID);
$stmt->execute();



$stmt->close();
$dbconnection->close();

?>