using System;

namespace _07.Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var numberOfItems = int.Parse(Console.ReadLine());
            var counter = 1;
            var ballance = 0.0;
            while (counter <= numberOfItems)
            {
                counter++;

                var name = Console.ReadLine();
                var price = double.Parse(Console.ReadLine());
                var itemQTY = int.Parse(Console.ReadLine());

                if (itemQTY > 1) name += "s";

                Console.WriteLine("Adding {0} {1} to cart.", itemQTY, name);

                ballance += price * itemQTY;
            }

            Console.WriteLine("Subtotal: ${0:f2}", ballance);

            if (budget >= ballance) Console.WriteLine("Money left: ${0:f2}", budget - ballance);
            else Console.WriteLine("Not enough. We need ${0:f2} more.", ballance - budget);


        }
    }
}
