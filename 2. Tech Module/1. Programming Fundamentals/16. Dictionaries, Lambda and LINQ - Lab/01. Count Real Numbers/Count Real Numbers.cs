namespace _01.Count_Real_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(number => double.Parse(number)).ToList();
            var result = new SortedDictionary<double, int>();

            for (int i = 0; i < myList.Count; i++)
            {
                var counter = 0;

                for (int j = myList.Count - 1; j >= i; j--)
                {
                    if (myList[i] == myList[j])
                    {
                        counter++;
                    }
                }

                if (!result.ContainsKey(myList[i]))
                {
                    result.Add(myList[i], counter);
                }
            }

            foreach (var number in result.Keys)
            {
                Console.WriteLine("{0} -> {1}", number, result[number]);
            }
        }
    }
}
