namespace _04.Hotel
{
    using System;

    public class Hotel
    {
        public static void Main()
        {
            var month = Console.ReadLine().ToLower();
            var nightCount = int.Parse(Console.ReadLine());
            double studioR = 0, doubleR = 0, suiteR = 0;
            double studioD = 1, doubleD = 1, suiteD = 1;
            var nightCountStudio = nightCount;
            var nightCountDouble = nightCount;
            var nightCountSuite = nightCount;

            if (month == "may" || month == "october")
            {
                studioR = 50;
                doubleR = 65;
                suiteR = 75;

                if (nightCount > 7)
                {
                    studioD = 0.95;
                }
            }
            else if (month == "june" || month == "september")
            {
                studioR = 60;
                doubleR = 72;
                suiteR = 82;

                if (nightCount > 14)
                {
                    doubleD = 0.9;
                }
            }
            else if (month == "july" || month == "august" || month == "december")
            {
                studioR = 68;
                doubleR = 77;
                suiteR = 89;

                if (nightCount > 14)
                {
                    suiteD = 0.85;
                }
            }

            if ((month == "september" || month == "october") && nightCount > 7)
            {
                nightCountStudio -= 1;
            }

            Console.WriteLine("Studio: {0:f2} lv.", (studioR * nightCountStudio) * studioD);
            Console.WriteLine("Double: {0:f2} lv.", (doubleR * nightCountDouble) * doubleD);
            Console.WriteLine("Suite: {0:f2} lv.", (suiteR * nightCountSuite) * suiteD);
        }
    }
}
