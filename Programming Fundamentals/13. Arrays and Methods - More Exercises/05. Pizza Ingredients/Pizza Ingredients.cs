namespace _05.Pizza_Ingredients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split(' ').ToArray();
            var length = int.Parse(Console.ReadLine());
            var counter = 0;
            List<string> myList = new List<string>();

            for (int i = 0; i < array.Length && counter <= 9; i++)
            {
                if (array[i].Length == length)
                {
                    Console.WriteLine("Adding {0}.", array[i]);
                    myList.Add(array[i]);
                    counter++;
                }
            }

            Console.WriteLine("Made pizza with total of {0} ingredients.", myList.Count);
            Console.WriteLine("The ingredients are: {0}.", string.Join(", ", myList));
        }
    }
}
