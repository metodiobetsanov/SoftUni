namespace _05.Weather_Forecast
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine();
            sbyte sbyteOut;
            int intOut;
            long longOut;
            decimal decimalOut;

            if (sbyte.TryParse(number, out sbyteOut))
            {
                Console.WriteLine("Sunny");
            }
            else if (int.TryParse(number, out intOut))
            {
                Console.WriteLine("Cloudy");
            }
            else if (long.TryParse(number, out longOut))
            {
                Console.WriteLine("Windy");
            }
            else if (decimal.TryParse(number, out decimalOut))
            {
                Console.WriteLine("Rainy");
            }
        }
    }
}
