namespace _04.Triple_Sum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var print = new List<long>();

            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    var sum = array[i] + array[j];
                    if (array.Contains(sum))
                    {
                        print.Add(array[i]);
                        print.Add(array[j]);
                        print.Add(sum);
                    }
                }
            }

            if (print.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (var i = 0; i < print.Count; i += 3)
                {
                    Console.WriteLine("{0} + {1} == {2}", print[i], print[i + 1], print[i + 2]);
                }
            }
        }
    }
}