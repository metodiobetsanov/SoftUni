numberOfStars = int(input())
star = '*'
space = ' '
print(star*numberOfStars)
for i in range(0,numberOfStars-2):
    print(star + space*(numberOfStars-2)+star)
print(star*numberOfStars)
