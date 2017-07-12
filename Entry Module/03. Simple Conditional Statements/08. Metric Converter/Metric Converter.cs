using System;

namespace _08.Metric_Converter
{
    class Program
    {
        static void Main()
        {
            var size = double.Parse(Console.ReadLine());
            var sourceMetric = Console.ReadLine().ToLower();
            var destMetric = Console.ReadLine().ToLower();
            var m = 1;
            var mm = 1000;
            var cm = 100;
            var mi = 0.000621371192;
            var inc = 39.3700787;
            var km = 0.001;
            var ft = 3.2808399;
            var yd = 1.0936133;

            if (sourceMetric == "m")
            {
                size = size / m;
            }
            else if (sourceMetric == "mm")
            {
                size = size / mm;
            }
            else if (sourceMetric == "cm")
            {
                size = size / cm;
            }
            else if (sourceMetric == "mi")
            {
                size = size / mi;
            }
            else if (sourceMetric == "in")
            {
                size = size / inc;
            }
            else if (sourceMetric == "km")
            {
                size = size / km;
            }
            else if (sourceMetric == "ft")
            {
                size = size / ft;
            }
            else if (sourceMetric == "yd")
            {
                size = size / yd;
            }


            if (destMetric == "m")
            {
                size = size * m;
            }
            else if (destMetric == "mm")
            {
                size = size * mm;
            }
            else if (destMetric == "cm")
            {
                size = size * cm;
            }
            else if (destMetric == "in")
            {
                size = size * inc;
            }
            else if (destMetric == "mi")
            {
                size = size * mi;
            }
            else if (destMetric == "ft")
            {
                size = size * ft;
            }
            else if (destMetric == "km")
            {
                size = size * km;
            }
            else if (destMetric == "yd")
            {
                size = size * yd;
            }

            Console.WriteLine(size + " " + destMetric);

        }
    }
}
