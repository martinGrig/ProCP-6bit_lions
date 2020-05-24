<?php
include 'dbconnect.php';

$ID = $_POST['ID'];
$stmt = $dblink->prepare("DELETE FROM simulation WHERE ID = ?");
$stmt->bind_param("i", $ID);
$stmt->execute();
$stmt->close();
$dblink->close();

?>