namespace _06.Sum_Reversed_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().Split(' ').ToList();
            var sum = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                var temp = myList[i].ToList();
                temp.Reverse();

                var number = int.Parse(string.Join("", temp));
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
