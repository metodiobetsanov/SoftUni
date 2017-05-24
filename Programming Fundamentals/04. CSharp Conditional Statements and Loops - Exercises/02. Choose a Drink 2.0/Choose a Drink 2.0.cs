using System;

namespace _02.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main()
        {
            var proffesion = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            var drink = 0.0;
            switch (proffesion)
            {
                case "Athlete": drink = 0.70;
                    break;
                case "Businessman": drink = 1.00;
                    break;
                case "Businesswoman": drink = 1.00;
                    break;
                case "SoftUni Student": drink = 1.70;
                    break;
                default: drink = 1.2;
                    break;
            }
            
            Console.WriteLine("The {0} has to pay {1:f2}.", 
                proffesion,
                quantity*drink);
        }
    }
}
