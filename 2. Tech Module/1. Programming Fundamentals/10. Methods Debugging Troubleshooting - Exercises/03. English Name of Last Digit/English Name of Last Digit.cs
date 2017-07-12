namespace _03.English_Name_of_Last_Digit
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = long.Parse(Console.ReadLine());
            NumberToText(number);
        }

        public static void NumberToText(long number)
        {
            string[] textUnits = new[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            var lastNumber = Math.Abs(number) % 10;
            Console.WriteLine("{0}", textUnits[lastNumber]);
        }
    }
}
