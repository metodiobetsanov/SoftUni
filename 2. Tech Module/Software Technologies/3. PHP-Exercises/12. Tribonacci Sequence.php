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
    $fOne = 1;
    echo $fOne;
    echo " ";
    $fTwo = 1;
    echo $fTwo;
    echo " ";
    $fThree = 2;
    echo $fThree;
    echo " ";
    $result = 0;
    for ($i = 3; $i < $num; $i++){
        $result = $fOne + $fTwo + $fThree;
        echo $result;
        echo " ";
        $fOne = $fTwo;
        $fTwo = $fThree;
        $fThree = $result;
    };
};
?>
</body>
</html>