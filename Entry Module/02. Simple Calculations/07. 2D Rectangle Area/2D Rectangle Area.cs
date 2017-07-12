using System;

namespace _07._2D_Rectangle_Area
{
    class Program
    {
        static void Main()
        {
            Console.Write("x1 = ");
            var x1 = double.Parse(Console.ReadLine());
            Console.Write("y1 = ");
            var y1 = double.Parse(Console.ReadLine());
            Console.Write("x2 = ");
            var x2 = double.Parse(Console.ReadLine());
            Console.Write("y2 = ");
            var y2 = double.Parse(Console.ReadLine());
            var hight = Math.Abs( x1 - x2 );
            var width = Math.Abs( y1 - y2 );
            var area = hight * width;
            var perimeter = 2 * (hight + width);

            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
