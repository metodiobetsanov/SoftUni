namespace _07.Bomb_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var token = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bomb = token[0];
            var power = token[1];

            while (myList.Contains(bomb))
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i] == bomb)
                    {
                        int left = Math.Max(i - power, 0);

                        int right = Math.Min(i + power, myList.Count - 1);

                        int lenght = right - left + 1;
                        myList.RemoveRange(left, lenght);
                        i = 0;
                    }
                }
            }

            Console.WriteLine(myList.Sum());
        }
    }
}
