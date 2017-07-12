namespace _04.Draw_a_Filled_Square
{
    using System;

    public class Program
    {
        public static void PrintTopBot(int number)
        {
            Console.WriteLine("{0}", new string('-', number*2));
        }

        public static void PrintBody(int number)
        {
            for (int i = 1; i <= number-2 ; i++)
            {
                Console.Write("-");
                for (int j = 1; j < number ; j++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine("-");
            }
        }

        public static void Print(int number)
        {
            PrintTopBot(number);
            PrintBody(number);
            PrintTopBot(number);
        }

        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            Print(number);
        }
    }
}
