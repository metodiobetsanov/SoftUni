namespace _01.Max_Sequence_of_Equal_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var longestSeq = 0;
            var LongestNumber = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                var counter = 0;

                for (int j = myList.Count - 1 ; j >= i; j--)
                {
                    if (myList[i] == myList[j])
                    {
                        counter++;
                    }
                }

                if (counter > longestSeq)
                {
                    longestSeq = counter;
                    LongestNumber = myList[i];
                }
            }

            for (int i = 0; i < longestSeq; i++)
            {
                Console.Write("{0} ", LongestNumber);
            }
        }
    }
}
