<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
<?php
for ($i = 0; $i < 9; $i++){
    for ($j = 0; $j < 5; $j++){
        if ($i == 0 || $i == 4 || $i == 8){
            ?><button style="background-color: blue;">1</button>
            <?php
        }else{
            if ($i < 4 && $j == 0){
                ?><button style="background-color: blue">1</button>
                <?php
            }elseif ($i > 4 && $j == 4){
                ?><button style="background-color: blue">1</button>
                <?php
            }else{
                ?><button>0</button>
                <?php
            }
        }
    }
    ?>
    <br/>
<?php }; ?>
</body>
</html>