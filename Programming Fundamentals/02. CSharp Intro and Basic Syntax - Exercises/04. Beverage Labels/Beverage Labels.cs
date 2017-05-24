using System;

namespace _04.Beverage_Labels
{
    class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energyContent = int.Parse(Console.ReadLine());
            var sugarContent = int.Parse(Console.ReadLine());
            double temp = volume / 100.00; 

            Console.WriteLine("{0}ml {1}:", 
                volume,
                name);
            Console.WriteLine("{0}kcal, {1}g sugars",
                energyContent*temp,
                sugarContent*temp);
        }
    }
}
