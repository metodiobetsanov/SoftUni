<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
<form>
    N: <input type="text" name="num" />
    <input type="submit" />
</form>
<?php
if (isset($_GET['num'])) {
    $num = intval($_GET['num']);
    for ($i = $num - 1; $i > 0; $i--){
        if (!is_int($num / $i)) {
            echo $i;
            echo " ";
        };
    };
};
?>
</body>
</html>