<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
// Initialize variable for database credentials
$dbhost = 'studmysql01.fhict.local';
$dbuser = 'dbi400672';
$dbpass = 'ProCPLions';
$dbname = 'dbi400672';

//Create database connection
  $dblink = new mysqli($dbhost, $dbuser, $dbpass, $dbname);

//Check connection was successful
  if ($dblink->connect_errno) {
     printf("Failed to connect to database");
     exit();
  }

?>