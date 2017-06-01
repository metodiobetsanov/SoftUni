namespace _10.Price_Change_Alert
{
    using System;

    public class Program
    {
        private static string Get(double prices, double lastPrice, double diff, bool TrueOrFalse)
        {
            string text = "";

            if (diff == 0)
            {
                text = string.Format("NO CHANGE: {0}", prices);
            }

            else if (!TrueOrFalse)
            {
                text = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, prices, diff * 100);
            }

            else if (TrueOrFalse && (diff > 0))
            {
                text = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, prices, diff * 100);
            }

            else if (TrueOrFalse && (diff < 0))
            {
                text = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, prices, diff * 100);
            }

            return text;
        }

        private static bool IsThereDiff(double border, double isDiff)
        {
            if (Math.Abs(border) >= isDiff)
            {
                return true;
            }
            return false;
        }

        private static double Proc(double diff, double border)
        {
            double result = (border - diff) / diff;
            return result;
        }

        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            double border = double.Parse(Console.ReadLine());
            double lastPrice = double.Parse(Console.ReadLine());

            for (int i = 0; i < number - 1; i++)
            {
                double prices = double.Parse(Console.ReadLine());
                double diff = Proc(lastPrice, prices);
                bool isSignificantDifference = IsThereDiff(border, diff);
                string message = Get(prices, lastPrice, diff, isSignificantDifference);
                Console.WriteLine(message);
                lastPrice = prices;
            }
        }
    }
}
