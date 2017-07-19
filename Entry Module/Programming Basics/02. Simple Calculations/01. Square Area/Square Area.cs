using System;


namespace _01.Square_Area
{
    class Program
    {
        static void Main()
        {
            var sideSize = Decimal.Parse(Console.ReadLine());
            var squareArea = sideSize * sideSize;
            
            Console.WriteLine("Square = {0}", squareArea);
        }
    }
}
