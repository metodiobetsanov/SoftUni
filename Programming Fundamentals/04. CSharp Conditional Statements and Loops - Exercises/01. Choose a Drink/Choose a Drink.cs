namespace _01.Choose_a_Drink
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var proffesion = Console.ReadLine();

            if (proffesion == "athlete")
            {
                Console.WriteLine("Water");
            }
            else if (proffesion == "businessman" || proffesion == "businesswoman")
            {
                Console.WriteLine("Coffee");
            }
            else if (proffesion == "softuni student")
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
