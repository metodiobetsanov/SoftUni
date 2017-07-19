using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sweet_Dessert
{
    class Program
    {
        static void Main(string[] args)
        {
            var amountOfCash = double.Parse(Console.ReadLine());
            var numberOfGuest = int.Parse(Console.ReadLine());
            var priceBananas = double.Parse(Console.ReadLine());
            var priceEgg = double.Parse(Console.ReadLine());
            var priceBerries = double.Parse(Console.ReadLine());
            var sets = (int)Math.Ceiling(numberOfGuest / 6.0);

            var oneSet = sets * (2 * priceBananas + 4 * priceEgg + 0.2 * priceBerries);

            if (amountOfCash >= oneSet)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:f2}lv.", oneSet);
            }
            else
            {
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:f2}lv more.", oneSet - amountOfCash);
            }
        }
    }
}
