<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop ( Name, Popularity, PriceRange, BusyHours, Category) VALUES (?,?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("sddss", $_POST['Name'], $_POST['Popularity'], $_POST['PriceRange'], $_POST['BusyHours'], $_POST['Category']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>