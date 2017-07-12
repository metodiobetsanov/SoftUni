namespace _07.Count_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            CountNumbers(myList);
        }

        private static void CountNumbers(List<int> myList)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

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

            var list = result.Keys.ToList();
            list.Sort();

            foreach (var key in list)
            {
                Console.WriteLine("{0} -> {1}", key, result[key]);
            }
        }
    }
}
