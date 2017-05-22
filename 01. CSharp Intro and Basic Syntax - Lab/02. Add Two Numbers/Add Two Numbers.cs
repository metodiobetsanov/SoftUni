using System;

namespace _02.Add_Two_Numbers
{
    class Program
    {
        static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            
            Console.Write("{0} + {1} = {2}",
                firstNumber,
                secondNumber,
                firstNumber + secondNumber);
        }
    }
}
