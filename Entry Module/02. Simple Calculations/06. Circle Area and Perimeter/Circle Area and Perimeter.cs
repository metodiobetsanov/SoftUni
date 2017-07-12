using System;

namespace _06.Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the radius: ");
            var r = double.Parse(Console.ReadLine());
            var area = Math.PI * r * r;
            var perimeter = 2 * Math.PI * r;

            Console.WriteLine("The area is {0}", area);
            Console.WriteLine("The perimeter is {0}", perimeter);
        }
    }
}
