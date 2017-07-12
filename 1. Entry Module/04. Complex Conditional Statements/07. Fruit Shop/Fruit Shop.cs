using System;

namespace _07.Fruit_Shop
{
    class Program
    {
        static void Main()
        {
            string product = Console.ReadLine().ToLower();
            string wDay = Console.ReadLine().ToLower();
            var qty = double.Parse(Console.ReadLine());
            var price = 0.0;

            if (wDay == "monday" || wDay == "tuesday" || wDay == "wednesday" || wDay == "thursday" || wDay == "friday")
            {
                switch (product)
                {
                    case "banana": price = 2.50;break;
                    case "apple": price = 1.20; break;
                    case "orange": price = 0.85; break;
                    case "grapefruit": price = 1.45; break;
                    case "kiwi": price = 2.70; break;
                    case "pineapple": price = 5.50; break;
                    case "grapes": price = 3.85; break;
                    default:
                        Console.WriteLine("error"); break;
                }

                Console.WriteLine("{0:f2}", price * qty);

            }

            else if (wDay == "saturday" || wDay == "sunday")
            {
                switch (product)
                {
                    case "banana": price = 2.70; break;
                    case "apple": price = 1.25; break;
                    case "orange": price = 0.90; break;
                    case "grapefruit": price = 1.60; break;
                    case "kiwi": price = 3.00; break;
                    case "pineapple": price = 5.60; break;
                    case "grapes": price = 4.20; break;
                    default:
                        Console.WriteLine("error"); break;
                }
                
                    Console.WriteLine("{0:f2}", price*qty);
               
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
