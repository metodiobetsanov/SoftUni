namespace _05.Calculate_Triangle_Area
{
    using System;

    public class Program
    {
        public static double GetArea(double width, double height)
        {
            double area = (width * height)/2;
            return area;
        }

        public static void Main()
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            double area = GetArea(width, height);

            Console.WriteLine(area);
        }
    }
}
