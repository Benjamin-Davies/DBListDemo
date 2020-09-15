<?php
$db_host = 'localhost';
$db_name = 'benjamindavies_db_list_demo';
$db_username = 'benjamindavies';
$db_password = file_get_contents('./password.txt');

try {
    $db = new PDO(
        "mysql:host=$db_host;" .
        "dbname=$db_name",
        $db_username, $db_password);
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    http_response_code(500);
    header('Content-Type: text/plain');
    echo "Failed to connect to db\n";
    echo $e;
    exit();
}
