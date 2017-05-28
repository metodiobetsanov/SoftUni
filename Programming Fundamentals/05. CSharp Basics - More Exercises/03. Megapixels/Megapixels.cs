using System;

namespace _03.Megapixels
{
    class Megapixels
    {
        static double MPConvert (double width, double height)
        {
            var result = Math.Round((width * height)/ 1000000, 1);
            return result;
        }

        static void Main(string[] args)
        {
            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            
            Console.WriteLine("{0}x{1} => {2}MP",
                width, height, MPConvert(width,height));
        }
    }
}
