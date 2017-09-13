using System.Collections.Generic;

namespace _01.Remove_Negatives_and_Reverse
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main()
        {
            List<int> myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] < 0 )
                {
                    myList.Remove(myList[i]);
                    i -= 1;
                }
            }

            if (myList.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                myList.Reverse();
                Console.WriteLine(string.Join(" ", myList));
            }
        }
    }
}
