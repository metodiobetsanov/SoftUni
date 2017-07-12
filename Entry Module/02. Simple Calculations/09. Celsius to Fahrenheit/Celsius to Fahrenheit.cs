using System;

namespace _09.Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main()
        {
            var celsius = double.Parse(Console.ReadLine());
            var fahrenheit = celsius * 1.8 + 32;

            Console.WriteLine(Math.Round(fahrenheit, 2));
        }
    }
}
