using System;
using System.Linq;

namespace _01.Choose_a_Drink
{
    class Program
    {
        static void Main()
        {
            var proffesion = Console.ReadLine().ToLower();
            if (proffesion== "athlete")
            {
                Console.WriteLine("Water");
            }
            else if (proffesion=="businessman" || proffesion== "businesswoman")
            {
                Console.WriteLine("Coffee");
            }
            else if (proffesion== "softuni student")
            {
                Console.WriteLine("Beer");
            }
            else
            {
                Console.WriteLine("Tea");
            }
        }
    }
}
