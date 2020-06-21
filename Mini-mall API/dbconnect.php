<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
// Initialize variable for database credentials
$dbhost = 'studmysql01.fhict.local';
$dbuser = 'dbi402538';
$dbpass = 'randompassword';
$dbname = 'dbi402538';

//Create database connection
  $dblink = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname);

//Check connection was successful
  if($dblink){
  }
  else{
      echo("Connection failed ". mysqli_errno(). "   " . mysqli_error());
  }

?>