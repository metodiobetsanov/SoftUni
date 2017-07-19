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
        $fTwo = 1;
        $result = 0;
        echo $fOne;
        echo " ";
        echo $fTwo;
        echo " ";
        for ($i = 2; $i < $num; $i++){
            $result = $fOne + $fTwo;
            echo $result;
            echo " ";
            $fOne = $fTwo;
            $fTwo = $result;
        };
    };
    ?>
</body>
</html>