using System;

namespace _06.Math_Power
{
    public class Program
    {
        public static double ToPower(double number, int power)
        {
            double result = number;
            for (int i = 1; i < power; i++)
            {
                result *= number;
            }

            return result;
        }

        public static void Main()
        {
            var number = double.Parse(Console.ReadLine());
            var power = int.Parse(Console.ReadLine());
            double result = ToPower(number, power);
            Console.WriteLine(result);
        }
    }
}
