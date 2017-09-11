using System;

namespace _05.Numbers_0_to_10_to_Text
{
    class Program
    {
        static void Main()
        {
            try
            {
                var num = int.Parse(Console.ReadLine());
                string[] textUnits = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Console.WriteLine(textUnits[num]);
            }
            catch (Exception)
            {
                Console.WriteLine("number too big");
            }
        }
    }
}
