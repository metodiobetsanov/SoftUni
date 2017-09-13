
money = float(input())
inputCurrency = input().lower()
outputCurrency = input().lower()
BGN = 1
USD = 1.79549
GBP = 2.53405
EUR = 1.95583
result = 0.0

if inputCurrency=="bgn":
    money *= BGN
    if outputCurrency == "usd":
        result = money / USD
    elif outputCurrency == "gbp":
        result = money / GBP
    elif (outputCurrency == "eur"):
        result = money / EUR

elif inputCurrency=="usd":
    money *= USD
    if (outputCurrency == "bgn"):
        result = money / BGN
    elif outputCurrency == "eur":
        result = money / EUR
    elif outputCurrency == "gbp":
        result = money / GBP

elif inputCurrency == "eur":
    money *= EUR
    if outputCurrency == "bgn":
        result = money / BGN
    elif outputCurrency == "usd":
        result = money / USD
    elif outputCurrency == "gbp":
        result = money / GBP

elif inputCurrency == "gbp":
    money *= GBP
    if outputCurrency == "bgn":
        result = money / BGN
    elif outputCurrency == "usd":
        result = money / USD
    elif outputCurrency == "eur":
        result = money / EUR


print(round(result, 2))