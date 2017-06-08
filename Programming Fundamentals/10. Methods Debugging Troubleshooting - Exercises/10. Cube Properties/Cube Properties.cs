using System.IO;

namespace _10.Cube_Properties
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var cubeSide = double.Parse(Console.ReadLine());
            var calculation = Console.ReadLine().ToLower();

            switch (calculation)
            {
                case "face": CubeFace(cubeSide);
                    break;
                case "space": CubeSpace(cubeSide);
                    break;
                case "volume": CubeVolume(cubeSide);
                    break;
                case "area": CubeArea(cubeSide);
                    break;
            }
        }

        public static void CubeFace(double cubeSide)
        {
            var result = Math.Sqrt(2 * Math.Pow(cubeSide, 2));
            Console.WriteLine("{0}", Math.Round(result, 2));
        }

        public static void CubeSpace(double cubeSide)
        {
            var result = Math.Sqrt(3 * Math.Pow(cubeSide, 2));
            Console.WriteLine("{0}", Math.Round(result, 2));
        }

        public static void CubeVolume(double cubeSide)
        {
            var result = Math.Pow(cubeSide, 3);
            Console.WriteLine("{0}", Math.Round(result, 2));
        }

        public static void CubeArea(double cubeSide)
        {
            var result = 6 * Math.Pow(cubeSide, 2);
            Console.WriteLine("{0}", Math.Round(result, 2));
        }
    }
}
