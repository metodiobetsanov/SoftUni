<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
for ($i = 0; $i < 5; $i++){
    $red = 51 * $i;
    $green = 51 * $i;
    $blue = 51 * $i;
    for ($j = 1; $j <= 10; $j++){ ?>
        <div style=" background-color: rgb(<?= $red ?>, <?= $green ?>, <?= $blue ?>)"></div>
        <?php
        $red += 5;
        $green += 5;
        $blue += 5;} ?>
    <br/>
<?php } ?>
</body>
</html>