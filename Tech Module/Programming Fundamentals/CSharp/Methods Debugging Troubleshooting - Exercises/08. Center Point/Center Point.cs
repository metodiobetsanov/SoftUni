namespace _08.Center_Point
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

            PrintCenterPoint(x1, y1, x2, y2);
        }

        private static void PrintCenterPoint(double x1, double y1, double x2, double y2)
        {
            if (Math.Abs(x1) == Math.Abs(x2) && Math.Abs(y1) == Math.Abs(y2))
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
            else
            {
                if (Math.Sqrt((x1 * x1) + (y1 * y1)) > Math.Sqrt((x2 * x2) + (y2 * y2)))
                {
                    Console.WriteLine("({0}, {1})", x2, y2);
                }
                else if (Math.Sqrt((x1 * x1) + (y1 * y1)) < Math.Sqrt((x2 * x2) + (y2 * y2)))
                {
                    Console.WriteLine("({0}, {1})", x1, y1);
                }
            }
        }
    }
}
