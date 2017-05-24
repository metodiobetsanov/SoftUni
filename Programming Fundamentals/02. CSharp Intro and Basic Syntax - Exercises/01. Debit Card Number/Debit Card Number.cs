using System;

namespace _01.Debit_Card_Number
{
    class Program
    {
        static void Main()
        {
            var fisrtFourDigits = int.Parse(Console.ReadLine());
            var secondFourDigits = int.Parse(Console.ReadLine());
            var thirdFourDigits = int.Parse(Console.ReadLine());
            var lastFourDigits = int.Parse(Console.ReadLine());
            Console.WriteLine("{0:D4} {1:D4} {2:D4} {3:D4}",
                fisrtFourDigits,
                secondFourDigits,
                thirdFourDigits,
                lastFourDigits);
        }
    }
}
