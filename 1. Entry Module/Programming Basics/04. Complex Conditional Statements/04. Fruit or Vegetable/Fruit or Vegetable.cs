using System;

namespace _04.Fruit_or_Vegetable
{
    class Program
    {
        static void Main()
        {
            string userIn = Console.ReadLine().ToLower();

            if (userIn == "banana" || userIn == "apple" || userIn == "kiwi" || userIn == "cherry" || userIn == "lemon" || userIn == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (userIn == "tomato" || userIn == "cucumber" || userIn == "pepper" || userIn == "carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
