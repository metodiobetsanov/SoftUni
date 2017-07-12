using System;

namespace _02.Inches_to_Centimeters
{
    class Program
    {
        static void Main()
        {
            Console.Write("Inches = ");
            var inches = double.Parse(Console.ReadLine());
            var centimeters = inches * 2.54;

            Console.WriteLine("Centimeters = {0}", centimeters);
        }
    }
}
