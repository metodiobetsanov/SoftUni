namespace _04.Largest_3_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            if (myList.Count<3)
            {
                Console.WriteLine(string.Join(" ", myList.OrderByDescending(number => number)));
            }
            else
            {
                Console.WriteLine(string.Join(" ", myList.OrderByDescending(number => number).Take(3)));
            }
        }
    }
}
