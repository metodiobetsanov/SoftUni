namespace _03.Search_for_a_Number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool found = false;

            myList = myList.Take(commands[0]).ToList();
            myList.RemoveRange(0, commands[1]);

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] == commands[2])
                {
                    found = true;
                }
            }

            Console.WriteLine(found ? "YES!" : "NO!");
        }
    }
}
