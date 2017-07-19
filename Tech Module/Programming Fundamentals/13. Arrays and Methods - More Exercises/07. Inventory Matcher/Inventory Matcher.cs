namespace _07.Inventory_Matcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(' ').ToArray();
            var quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            List<string> myList = new List<string>();

            while (true)
            {
                var goods = Console.ReadLine();
                if (goods == "done")
                {
                    break;
                }
                else
                {
                    myList.Add(goods);
                }
            }

            for (int i = 0; i < myList.Count; i++)
            {
                var index = Array.IndexOf(names, myList[i]);
                Console.WriteLine("{0} costs: {1}; Available quantity: {2}", names[index], prices[index], quantities[index]);
            }
        }
    }
}
