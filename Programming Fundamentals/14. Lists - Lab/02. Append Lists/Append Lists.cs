namespace _02.Append_Lists
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split('|').ToArray();
            List<string> myList = new List<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                var temp = input[i].Trim().Split(' ').ToArray();
                for (int j = 0; j < temp.Length; j++)
                {
                    myList.Add(temp[j]);
                }

            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
