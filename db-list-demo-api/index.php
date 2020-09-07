<?php
require('connect.php');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
  $sql = 'SELECT * FROM todos';
  $stmt = $db->prepare($sql);
  $stmt->execute();

  foreach ($stmt as $todo) {
    echo $todo['title'] . "\n";
  }
}

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
  $sql = 'INSERT INTO todos (title) VALUES (?)';
  $stmt = $db->prepare($sql);
  $stmt->execute(array($_POST['title']));
}
?>
