namespace _06.Square_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> results = new List<int>();

            for (int i = 0; i < myList.Count; i++)
            {
                if (Math.Sqrt(myList[i]) == (int)Math.Sqrt(myList[i]))
                {
                    results.Add(myList[i]);
                }
            }

            results.Sort((a, b) => b.CompareTo(a));
            Console.WriteLine(string.Join(" ", results));
        }
    }
}
