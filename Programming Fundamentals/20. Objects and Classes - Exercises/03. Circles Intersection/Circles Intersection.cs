namespace _03.Circles_Intersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Circle c1 = Circle.ReadData();
            Circle c2 = Circle.ReadData();

            double distance = Circle.CalcDistance(c1, c2);

            if (distance <= c1.Radius + c2.Radius)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }

    class Circle
        {
            public double X { get; set; }

            public double Y { get; set; }

            public double Radius { get; set; }

            public static Circle ReadData()
            {
                double[] pointInfo = Console.ReadLine().Split().Select(double.Parse).ToArray();
                Circle c = new Circle();

                c.X = pointInfo[0];
                c.Y = pointInfo[1];
                c.Radius = pointInfo[2];
                return c;
            }

            public static double CalcDistance(Circle c1, Circle c2)
            {
                var sideA = Math.Abs(c1.X - c2.X);
                var sideB = Math.Abs(c1.Y - c2.Y);

                var distance = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

                return distance;
            }
        }
    }

