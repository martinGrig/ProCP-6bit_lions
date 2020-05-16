<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

$dbhost = 'studmysql01.fhict.local';
$dbuser = 'dbi400672';
$dbpassword = 'ProCPLions';
$db = 'dbi400672';
$dbport = 3306;

$dbconnection = mysqli_connect($dbhost, $dbuser, $dbpassword, $db);

if($dbconnection){
}
else{
    echo("Connection failed " . mysql_error());
}
?>