<?php
include 'dbconnect.php';

$sql = "INSERT INTO shop (ID, Name, Capacity, Popularity, PriceRange, BusyHours, Category) VALUES (?,?,?,?,?,?,?)";
$stmt = $dblink->prepare($sql);
$stmt->bind_param("isiddss", $_POST['ID'], $_POST['Name'], $_POST['Capacity'], $_POST['Popularity'], $_POST['PriceRange'], $_POST['BusyHours'], $_POST['Category']);
$stmt->execute();
$stmt->close();
$dblink->close();

?>