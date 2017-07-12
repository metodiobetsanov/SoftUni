using System;

namespace _10.Price_Change_Alert
{
    public class Program
    {
        private static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var limitPrice = double.Parse(Console.ReadLine());
            var lastPrice = double.Parse(Console.ReadLine());

            for (var i = 0; i < lines - 1; i++)
            {
                var currentPrice = double.Parse(Console.ReadLine());
                var difference = Proc(lastPrice, currentPrice);
                var isSignificantDifference = isThereDIff(difference, limitPrice);
                var message = GetDiff(currentPrice, lastPrice, difference, isSignificantDifference);
                Console.WriteLine(message);
                lastPrice = currentPrice;
            }
        }

        private static string GetDiff(double currentPrice, double lastPrice, double difference, bool etherTrueOrFalse)
        {
            var message = "";
            if (difference == 0)
            {
                message = string.Format("NO CHANGE: {0}", currentPrice);
            }
            else if (!etherTrueOrFalse)
            {
                message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference * 100);
            }
            else if (etherTrueOrFalse && difference > 0)
            {
                message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference * 100);
            }
            else if (etherTrueOrFalse && difference < 0)
            {
                message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, difference * 100);
            }
            return message;
        }

        private static bool isThereDIff(double limitPrice, double isDiff)
        {
            if (Math.Abs(limitPrice) >= isDiff)
            {
                return true;
            }
            return false;
        }

        private static double Proc(double lastPrice, double currentPrice)
        {
            var result = (currentPrice - lastPrice) / lastPrice;
            return result;
        }
    }
}