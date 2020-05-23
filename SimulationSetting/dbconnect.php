<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

$dbhost = 'studmysql01.fhict.local';
$dbuser = 'dbi400672';
$dbpassword = 'ProCPLions';
$db = 'dbi400672';
$dbport = 3306;
private $connection;

/*
$dbconnection = mysqli_connect($dbhost, $dbuser, $dbpassword, $db);

if($dbconnection){
    connect
}
else{
    echo("Connection failed " . mysql_error());
}
*/
///

public function connect() {

    $this->connection = null;

    try { //dsn - database type and host, takes all necessary parametres from above in order to connect
        $this->connection = new PDO('mysql:host=' . $this->dbhost . ';dbname=' . $this->db, $this->dbuser, $this->dbpassword);
        $this->connection->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    }
    catch(PDOException $e){
        echo 'Connection Error: ' . $e->getMessage();
    }

    return $this->connection;
}

?>