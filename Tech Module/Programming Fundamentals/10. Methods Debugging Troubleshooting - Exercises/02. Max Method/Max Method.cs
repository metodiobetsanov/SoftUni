namespace _02.Max_Method
{
    using System;

    public class Program
    {
        public static double GetMax(double numberOne, double numberTwo)
        {
            if (numberOne > numberTwo)
            {
                return numberOne;
            }
            else
            {
                return numberTwo;
            }
        }

        public static void Main()
        {
            var numberOne = double.Parse(Console.ReadLine());
            var numberTwo = double.Parse(Console.ReadLine());
            var numberThree = double.Parse(Console.ReadLine());

            Console.WriteLine("{0}", GetMax(GetMax(numberOne, numberTwo), numberThree));
        }
    }
}