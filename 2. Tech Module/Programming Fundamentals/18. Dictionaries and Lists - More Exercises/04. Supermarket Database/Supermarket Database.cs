namespace _04.Supermarket_Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var stocks = new Dictionary<string, double[]>();
            var grandTotal = 0.0;

            while (true)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var stock = input[0];

                if (stock == "stocked")
                {
                    break;
                }

                var price = double.Parse(input[1]);
                var quantity = double.Parse(input[2]);
                
                if (!stocks.ContainsKey(stock))
                {
                    stocks[stock] = new double[2];
                    stocks[stock][0] = 0;
                    stocks[stock][1] = 0;
                }

                stocks[stock][0] = price;
                stocks[stock][1] += quantity;
            }

            foreach (var item in stocks)
            {
                var name = item.Key;
                var details = item.Value.ToArray();
                var price = details[0];
                var quantity = details[1];
                var total = price * quantity;
                grandTotal += total;

                Console.WriteLine("{0}: ${1:F2} * {2} = ${3:F2}",
                    name,
                    price,
                    quantity,
                    total);
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Grand Total: ${0:F2}", grandTotal);
        }
    }
}
