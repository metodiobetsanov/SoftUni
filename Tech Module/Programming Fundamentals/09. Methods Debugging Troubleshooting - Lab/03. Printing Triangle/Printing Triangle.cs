namespace _03.Printing_Triangle
{
    using System;

    public class Program
    {
        public static void PrintTriangle(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                PrintContent(i);
            }
            for (int i = number - 1; i >= 0; i--)
            {
                PrintContent(i);
            }
        }

        public static void PrintContent(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Console.Write("{0} ", i);
            }
            
            Console.WriteLine();
        }

        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
        }
    }
}
