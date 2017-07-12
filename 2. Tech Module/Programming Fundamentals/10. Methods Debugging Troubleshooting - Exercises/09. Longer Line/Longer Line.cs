namespace _09.Longer_Line
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var x3 = double.Parse(Console.ReadLine());
            var y3 = double.Parse(Console.ReadLine());
            var x4 = double.Parse(Console.ReadLine());
            var y4 = double.Parse(Console.ReadLine());

            var firstLine = LineLength(x1, y1, x2, y2);
            var secondLine = LineLength(x3, y3, x4, y4);

            if (firstLine >= secondLine)
            {
                PrintCenterPoint(x1, y1, x2, y2);
            }
            else
            {
                PrintCenterPoint(x3, y3, x4, y4);
            }
        }

        private static double LineLength(double x1, double y1, double x2, double y2)
        {
            double lineLength = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
            return lineLength;
        }

        private static void PrintCenterPoint(double x1, double y1, double x2, double y2)
        {
                if (Math.Sqrt((x1 * x1) + (y1 * y1)) > Math.Sqrt((x2 * x2) + (y2 * y2)))
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
                }
                else if (Math.Sqrt((x1 * x1) + (y1 * y1)) <= Math.Sqrt((x2 * x2) + (y2 * y2)))
                {
                    Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
                }
        }
    }
}
