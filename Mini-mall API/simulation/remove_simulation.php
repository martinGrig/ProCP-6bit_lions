<?php
include 'dbconnect.php';

$Name = $_POST['Name'];
$stmt = $dblink->prepare("DELETE FROM simulation WHERE Name = ?");
$stmt->bind_param("s", $Name);
$stmt->execute();
$stmt->close();
$dblink->close();

?>