using System;

namespace _08.Triangle_Area
{
    class Program
    {
        static void Main()
        {
            var side = double.Parse(Console.ReadLine());
            var hight = double.Parse(Console.ReadLine());
            var area = side * (hight / 2);

            Console.WriteLine(Math.Round(area, 2));
        }
    }
}
