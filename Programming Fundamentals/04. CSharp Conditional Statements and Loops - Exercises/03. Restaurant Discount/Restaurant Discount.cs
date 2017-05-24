using System;

namespace _03.Restaurant_Discount
{
    class Program
    {
        static void Main()
        {
            var groupSize = int.Parse(Console.ReadLine());
            var package = Console.ReadLine().ToLower();
            string hall = null;
            var price = 0.0;
            if (groupSize <= 50)
            {
                hall = "Small Hall";
                price = 2500;

                if (package == "normal")
                {
                    price += 500;
                    price -= price * 0.05;
                }
                else if (package == "gold")
                {
                    price += 750;
                    price -= price * 0.1;
                }
                else if (package == "platinum")
                {
                    price += 1000;
                    price -= price * 0.15;
                }
                Console.WriteLine("We can offer you the {0}", hall);
                Console.WriteLine("The price per person is {0:f2}$", price / groupSize);
            }

            else if (groupSize <= 100)
            {
                hall = "Terrace";
                price = 5000;

                if (package == "normal")
                {
                    price += 500;
                    price -= price * 0.05;
                }
                else if (package == "gold")
                {
                    price += 750;
                    price -= price * 0.1;
                }
                else if (package == "platinum")
                {
                    price += 1000;
                    price -= price * 0.15;
                }
                
                Console.WriteLine("We can offer you the {0}", hall);
                Console.WriteLine("The price per person is {0:f2}$", price / groupSize);
            }

            else if (groupSize <= 120)
            {
                hall = "Great Hall";
                price = 7500;

                if (package == "normal")
                {
                    price += 500;
                    price -= price * 0.05;
                }
                else if (package == "gold")
                {
                    price += 750;
                    price -= price * 0.1;
                }
                else if (package == "platinum")
                {
                    price += 1000;
                    price -= price * 0.15;
                }
                Console.WriteLine("We can offer you the {0}", hall);
                Console.WriteLine("The price per person is {0:f2}$", price / groupSize);
            }

            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}
