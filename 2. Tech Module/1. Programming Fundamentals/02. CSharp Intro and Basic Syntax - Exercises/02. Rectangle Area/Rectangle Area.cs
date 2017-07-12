namespace _02.Rectangle_Area
{
    using System;

    public class Program
    {
        public static float RectangleArea(float width, float height)
        {
            var rectangleArea = width * height;
            return rectangleArea;
        }

        public static void Main()
        {
            var width = float.Parse(Console.ReadLine());
            var height = float.Parse(Console.ReadLine());
            var result = RectangleArea(width, height);

            Console.WriteLine("{0:F2}", result);
        }
    }
}
