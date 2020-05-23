<?php
include 'dbconnect.php';

$query = "SELECT * FROM shop;";
$result = mysqli_query($dbconnection, $query);

if(!$result)
{
    echo"There was an error with the query!";
    exit();
}

$shops = [];

if($result)
{
    if($result->num_rows === 0) exit('No rows');
    while($row = mysqli_fetch_assoc($result))
    {
        array_push($shops, [
            'ID' => $row['ID'],
            'PositionID' => $row['PositionID'],
            'Name' => $row['Name'],
            'Capacity' => $row['Capacity'],
            'Popularity' => $row['Popularity'],
            'PriceRange' => $row['PriceRange'],
            'BusyHours' => $row['BusyHours'],
            'Category' => $row['Category']
            ])
    }
    echo json_encode($shops);
}

header('Content-Type: application/json');

?>