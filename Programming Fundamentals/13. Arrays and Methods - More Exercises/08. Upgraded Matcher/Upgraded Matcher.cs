namespace _08.Upgraded_Matcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {

            var names = Console.ReadLine().Split(' ').ToArray();
            var quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            List<string> myGoods = new List<string>();
            List<long> myQuantities = new List<long>();

            while (true)
            {
                var goods = Console.ReadLine().Split(' ').ToArray();
                if (goods[0] == "done")
                {
                    break;
                }
                else
                {
                    var index = Array.IndexOf(names, goods[0]);
                    if ((index >= quantities.Length) || (quantities[index] < long.Parse(goods[1])))
                    {
                        Console.WriteLine(
                            "We do not have enough {0}",
                            names[index]);
                    }
                    else
                    {
                            Console.WriteLine(
                                "{0} x {1} costs {2:f2}",
                                names[index],
                                goods[1],
                                long.Parse(goods[1]) * prices[index]);

                            quantities[index] -= long.Parse(goods[1]);
                    }
                }
            }
        }
    }
}
