using System;

namespace _15._3_Equal_Numbers
{
    class Program
    {
        static void Main()
        {
            double numOne = double.Parse(Console.ReadLine());
            double numTwo = double.Parse(Console.ReadLine());
            double numThree = double.Parse(Console.ReadLine());

            if (numOne == numTwo && numTwo == numThree)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
