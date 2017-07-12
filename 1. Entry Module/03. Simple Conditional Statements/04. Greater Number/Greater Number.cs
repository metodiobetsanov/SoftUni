using System;

namespace _04.Greater_Number
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter two integers:");
            var numOne = int.Parse(Console.ReadLine());
            var numTwo = int.Parse(Console.ReadLine());
            if (numOne > numTwo)
            {
                Console.WriteLine("Greater number: " + numOne);
            }
            else
            { 
            Console.WriteLine("Greater number: " + numTwo);
            }
        }
    }
}
