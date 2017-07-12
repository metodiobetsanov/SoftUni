using System;

namespace _07.Greatest_Common_Divisor__CGD_
{
    class Program
    {
        static void Main()
        {
            var numOne = int.Parse(Console.ReadLine());
            var numTwo = int.Parse(Console.ReadLine());
            while (numTwo != 0)
            {
                var oldB = numTwo;
                numTwo = numOne % numTwo;
                numOne = oldB;
            }
            Console.WriteLine(numOne);
        }
    }
}
