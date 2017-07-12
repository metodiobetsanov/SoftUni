namespace _03.Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
            while (true)
            {
                var counter = 0;
                for (int i = 0; i < myList.Count - 1; i++)
                {
                    decimal sum = 0;
                    if (myList[i] == myList[i + 1])
                    {
                        sum = myList[i] + myList[i + 1];
                        myList.RemoveAt(i);
                        myList.RemoveAt(i);
                        myList.Insert(i, sum);
                        counter++;
                    }
                }

                if (counter == 0)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
