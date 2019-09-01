<?php

$conn = mysqli_connect('localhost', 'root', 'root', 'gamedata'); //attempt to connect to database by entering host, user, password, and db name

if (mysqli_connect_errno())
{ //check if connection failed

    die("failed to connect to database"); //echo error message if connection failed
}

$user = $_POST["name"]; //get variables from form posted and store them in php variables
$pass = $_POST["password"];

$checknamequery = "SELECT user FROM players WHERE (user = '".$user."');";

$namecheck = mysqli_query($conn, $checknamequery) or die("Name check query failed"); //run name check query and check if name check query fail

if (mysqli_num_rows($namecheck) > 0)
{
    die("Username already exists");
}

    $salt = "\$5\$rounds=5000\$" . "randomnum" . $user . "\$"; //encryption
    $hash = crypt($pass, $salt); //combination of encrypting password with salt

    $insertquery = "INSERT INTO players (user, hash, salt) VALUES('".$user."', '".$hash."' , '".$salt."');"; //insertion query //because they are strings, must concatenate
    mysqli_query($conn, $insertquery) or die ("Insertion query failed"); //error in running query to insert


echo("registration sucesss");
?>