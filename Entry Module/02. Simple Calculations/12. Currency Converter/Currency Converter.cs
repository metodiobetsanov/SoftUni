using System;

namespace _12.Currency_Converter
{
    class Program
    {
        static void Main()
        {
            var money = double.Parse(Console.ReadLine());
            var inputCurrency = Console.ReadLine().ToLower();
            var outputCurrency = Console.ReadLine().ToLower();
            var BGN = 1;
            var USD = 1.79549;
            var GBP = 2.53405;
            var EUR = 1.95583;
            var result = 0.0;

            if (inputCurrency=="bgn")
            {
                money *= BGN;

                if (outputCurrency == "usd")
                {
                    result = money / USD;
                }
                else if (outputCurrency == "gbp")
                {
                    result = money / GBP;
                }
                else if (outputCurrency == "eur")
                {
                    result = money / EUR;
                }
            }

            else if (inputCurrency=="usd")
            {
                money *= USD;

                if (outputCurrency == "bgn")
                {
                    result = money / BGN;
                }
                else if (outputCurrency == "eur")
                {
                    result = money / EUR;
                }
                else if (outputCurrency == "gbp")
                {
                    result = money / GBP;
                }
            }

            else if (inputCurrency == "eur")
            {
                money *= EUR;

                if (outputCurrency == "bgn")
                {
                    result = money / BGN;
                }
                else if (outputCurrency == "usd")
                {
                    result = money / USD;
                }
                else if (outputCurrency == "gbp")
                {
                    result = money / GBP;
                }
            }

            else if (inputCurrency == "gbp")
            {
                money *= GBP;

                if (outputCurrency == "bgn")
                {
                    result = money / BGN;
                }
                else if (outputCurrency == "usd")
                {
                    result = money / USD;
                }
                else if (outputCurrency == "eur")
                {
                    result = money / EUR;
                }
            }

            Console.WriteLine(Math.Round(result, 2));
        }
    }
}
