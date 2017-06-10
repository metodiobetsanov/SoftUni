namespace _11.Geometry_Calculator
{
    using System;

    class Program
    {
        static void Main()
        {
            var figure = Console.ReadLine().ToLower();

            switch (figure)
            {
                case "triangle":
                    TriangleArea();
                    break;
                case "square":
                    SquareArea();
                    break;
                case "rectangle":
                    RectangleArea();
                    break;
                case "circle":
                    CircleArea();
                    break;
                default: break;
            }
        }

        private static void TriangleArea()
        {
            var side = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            double result = (side * height) / 2;

            Console.WriteLine("{0:f2}", result);
        }

        private static void SquareArea()
        {
            var side = double.Parse(Console.ReadLine());
            double result = Math.Pow(side, 2);

            Console.WriteLine("{0:f2}", result);
        }

        private static void RectangleArea()
        {
            var side = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            double result = side * height;

            Console.WriteLine("{0:f2}", result);
        }

        private static void CircleArea()
        {
            var r = double.Parse(Console.ReadLine());
            double result = Math.PI * Math.Pow(r, 2);

            Console.WriteLine("{0:f2}", result);
        }
    }
}
