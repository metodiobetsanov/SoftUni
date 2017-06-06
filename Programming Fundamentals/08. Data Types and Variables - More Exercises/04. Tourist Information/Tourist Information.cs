namespace _04.Tourist_Information
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var initialImperialUnit = Console.ReadLine().ToLower();
            var initialValue = double.Parse(Console.ReadLine());
            var convertedValue = 0.0;
            var metricUnit = string.Empty;
            
            switch (initialImperialUnit)
            {
                case "miles": convertedValue = initialValue * 1.6;
                    metricUnit = "kilometers";
                    break;
                case "inches": convertedValue = initialValue * 2.54;
                    metricUnit = "centimeters";
                    break;
                case "feet": convertedValue = initialValue * 30;
                    metricUnit = "centimeters";
                    break;
                case "yards": convertedValue = initialValue * 0.91;
                    metricUnit = "meters";
                    break;
                case "gallons":
                    convertedValue = initialValue * 3.8;
                    metricUnit = "liters";
                    break;
                default: break;
            }

            Console.WriteLine($"{initialValue} {initialImperialUnit} = {convertedValue:f2} {metricUnit}");
        }
    }
}
