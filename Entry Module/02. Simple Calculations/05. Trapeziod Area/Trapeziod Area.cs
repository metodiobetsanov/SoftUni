using System;

namespace _05.Trapeziod_Area
{
    class Program
    {
        static void Main()
        {
            Console.Write("b1 = ");
            var b1 = double.Parse(Console.ReadLine());
            Console.Write("b2 = ");
            var b2 = double.Parse(Console.ReadLine());
            Console.Write("h1 = ");
            var h = double.Parse(Console.ReadLine());
            var area = (b1 + b2) * h / 2;

            Console.WriteLine("The Trapezoid Area is: {0}", area);
        }
    }
}
