using System;

namespace _08.Trade_Comissions
{
    class Program
    {
        static void Main()
        {
            string town = Console.ReadLine().ToLower();
            double sales = double.Parse(Console.ReadLine().ToLower());
            double comPer = -0.1;

            if (town == "sofia")
            {
                if (0 <= sales && sales <= 500)
                {
                    comPer = 0.05;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comPer = 0.07;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comPer = 0.08;
                }
                else if (10000 < sales)
                {
                    comPer = 0.12;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if (town == "varna")
            {
                if (0 <= sales && sales <= 500)
                {
                    comPer = 0.045;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comPer = 0.075;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comPer = 0.10;
                }
                else if (10000 < sales)
                {
                    comPer = 0.13;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if (town == "plovdiv")
            {
                if (0 <= sales && sales <= 500)
                {
                    comPer = 0.055;
                }
                else if (500 < sales && sales <= 1000)
                {
                    comPer = 0.08;
                }
                else if (1000 < sales && sales <= 10000)
                {
                    comPer = 0.12;
                }
                else if (10000 < sales)
                {
                    comPer = 0.145;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else
            {
                Console.WriteLine("error");
            }

            Console.WriteLine("{0:f2}", sales * comPer);

        }
    }
}
