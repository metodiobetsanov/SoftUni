namespace _03.Megapixels
{
    using System;

    public class Megapixels
    {
        public static double MPConvert(double width, double height)
        {
            var result = Math.Round((width * height) / 1000000, 1);
            return result;
        }

        public static void Main()
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            
            Console.WriteLine("{0}x{1} => {2}MP", width, height, MPConvert(width, height));
        }
    }
}
