<?php
require('connect.php');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
  $sql = 'SELECT * FROM todos ORDER BY id';
  $stmt = $db->prepare($sql);
  $stmt->execute();

  foreach ($stmt as $todo) {
    echo $todo['title'] . "\n";
  }
} elseif ($_SERVER['REQUEST_METHOD'] == 'POST') {
  $sql = 'INSERT INTO todos (title) VALUES (?)';
  $stmt = $db->prepare($sql);
  $stmt->execute(array($_POST['title']));
} elseif ($_SERVER['REQUEST_METHOD'] == 'DELETE') {
  $n = $_GET['n'] - 1;
  # Normally you would never put any valiable directly into your SQL like this,
  # however I could not get it working any other way and the line above ensures
  # that the value can only be a number.
  $sql = 'DELETE FROM todos WHERE id=(SELECT id FROM todos ORDER BY id LIMIT '.$n.', 1)';
  $stmt = $db->prepare($sql);
  $stmt->execute();
} else {
  http_response_code(405);
}
?>
