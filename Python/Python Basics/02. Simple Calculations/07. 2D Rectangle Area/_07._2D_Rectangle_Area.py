
import math
x1 = float(input())
y1 = float(input())
x2 = float(input())
y2 = float(input())
hight = math.fabs( x1 - x2 )
width = math.fabs( y1 - y2 )
area = hight * width
perimeter = 2 * (hight + width)
print(area)
print(perimeter)