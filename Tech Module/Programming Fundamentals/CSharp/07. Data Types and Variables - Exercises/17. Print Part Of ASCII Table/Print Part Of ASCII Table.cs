namespace _17.Print_Part_Of_ASCII_Table
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                var tmp = (char)i;
                Console.Write($"{tmp} ");
            }

            Console.WriteLine();
        }
    }
}
