namespace _09.Extract_Middle_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var length = array.Length;

            if (length == 1)
            {
                Console.WriteLine("( {0} )", array[0]);
            }
            else
            {
                if (length % 2 == 0)
                {
                    Console.WriteLine("( {0}, {1} )", array[length / 2 - 1], array[length / 2]);
                }
                else
                {
                    Console.WriteLine("( {0}, {1}, {2} )", array[length / 2 - 1], array[length / 2], array[length / 2 + 1]);
                }
            }
        }
    }
}
