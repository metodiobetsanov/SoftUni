using System;

namespace _13.Point_in_the_Figure
{
    class Program
    {
        static void Main()
        {
            var h = int.Parse(Console.ReadLine());
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());
            var x11 = 0;
            var y11 = 0;
            var x12 = 3 * h;
            var y12 = h;
            var x21 = h;
            var y21 = h;
            var x22 = 2 * h;
            var y22 = 4 * h;

            bool inFig1 = (x11 < x && x < x12 && y11 < y && y < y12) || (y12 == y && h < x && x < x22);
            bool inFig2 = x21 < x && x < x22 && y21 < y && y < y22;

            bool borderFig1 = ((x == x11 || x == x12) && (y11 <= y && y <= y12)) || (((x11 <= x && x <= x12) && y == y11) || ((((x11 <= x && x <= x12) || (x22 <= x && x <= x12)) && y == y12)));
            bool borderFig2 = ((x == x21 || x == x22) && (y21 <= y && y <= y22)) || (((x21 <= x && x <= x22) && y == y22) || (y == y21 && (x21 == x || x == x22)));

            if (inFig1 || inFig2)
            {
                Console.WriteLine("inside");
            }

            else if (borderFig1 || borderFig2)
            {
                Console.WriteLine("border");
            }

            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
