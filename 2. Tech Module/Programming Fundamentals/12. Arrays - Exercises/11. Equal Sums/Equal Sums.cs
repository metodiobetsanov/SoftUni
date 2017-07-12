namespace _11.Equal_Sums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            List<int> myList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                var rightSum = 0;
                var leftSum = 0;
                
                    for (int l = 0; l < i; l++)
                    {
                        leftSum += array[l];
                    }

                    for (int r = array.Length - 1; r > i; r--)
                    {
                        rightSum += array[r];
                    }
               

                if (leftSum == rightSum)
                {
                    myList.Add(i);
                }
            }

            if (myList.Count == 0)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine(string.Join("", myList));
            }
        }
    }
}
