namespace _04.Distance_between_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            Point p1 = Point.ReadPoint();
            Point p2 = Point.ReadPoint();

            double distance = Point.CalcDistance(p1, p2);

            Console.WriteLine("Distance: {0:f3}", distance);

        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point ReadPoint()
        {
            int[] pointInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point point = new Point();

            point.X = pointInfo[0];
            point.Y = pointInfo[1];

            return point;
        }


        public static double CalcDistance(Point p1, Point p2)
        {
            var sideA = Math.Abs(p1.X - p2.X);
            var sideB = Math.Abs(p1.Y - p2.Y);

            var distance = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return distance;
        }
    }
}
