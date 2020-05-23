<?php
include 'dbconnect.php';

$query = "SELECT * FROM simulation;";
$result = mysqli_query($dbconnection, $query);

if(!$result)
{
    echo"There was an error with the query!";
    exit();
}

$simulations = [];

if($result)
{
    if($result->num_rows === 0) exit('No rows');
    while($row = mysqli_fetch_assoc($result))
    {
        array_push($simulations, [
            'ID' => $row['ID'],
            'StartTime' => $row['StartTime'],
            'EndTime' => $row['EndTime'],
            'Weather' => $row['Weather'],
            'Holiday' => $row['Holiday'],
            'DayOfTheWeek' => $row['DayOfTheWeek'],
            'Sales' => $row['Sales']
            ])
    }
    echo json_encode($simulations);
}

header('Content-Type: application/json');

?>