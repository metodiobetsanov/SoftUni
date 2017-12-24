namespace _05.Closest_Two_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Point[] points = Point.ReadPoints();
            Point[] closestPoints = Point.FindClosestTwoPoints(points);

            Point.PrintDistance(closestPoints);

            Point.PrintPoint(closestPoints[0]);
            Point.PrintPoint(closestPoints[1]);

        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point[] points { get; set; }

        public static Point ReadPoint()
        {
            int[] pointInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point point = new Point();

            point.X = pointInfo[0];
            point.Y = pointInfo[1];

            return point;
        }

        public static Point[] ReadPoints()
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = ReadPoint();
            }

            return points;
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            var sideA = Math.Abs(p1.X - p2.X);
            var sideB = Math.Abs(p1.Y - p2.Y);

            var distance = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return distance;
        }

        public static Point[] FindClosestTwoPoints(Point[] points)
        {
            double minDistance = double.MaxValue;
            Point[] closestTwoPoints = null;
            for (int p1 = 0; p1 < points.Length; p1++)
            for (int p2 = p1 + 1; p2 < points.Length; p2++)
            {
                double distance = CalcDistance(points[p1], points[p2]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTwoPoints = new Point[] { points[p1], points[p2] };
                }
            }
            return closestTwoPoints;
        }

        public static void PrintPoint(Point point)
        {
            Console.WriteLine("({0}, {1})", point.X, point.Y);
        }

        public static void PrintDistance(Point[] points)
        {
            double distance = CalcDistance(points[0], points[1]);
            Console.WriteLine("{0:f3}", distance);
        }
    }
}