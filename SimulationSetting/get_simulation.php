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
            'ID' => $row['ID']]);
    }
    echo json_encode($simulations);
}

header('Content-Type: application/json');

?>