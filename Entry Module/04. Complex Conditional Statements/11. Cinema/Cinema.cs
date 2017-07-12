using System;

namespace _11.Cinema
{
    class Cinema
    {
        static void Main()
        {
            string promo = Console.ReadLine().ToLower();
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());
            var cinemaCap = row * col;
            double price = -1.0;

            switch (promo)
            {
                case "premiere": price = 12.00; break;
                case "normal": price = 7.5; break;
                case "discount": price = 5.0; break;
                default: Console.WriteLine("error"); break;
            }

            Console.WriteLine("{0:f2}", price * cinemaCap);
        }
    }
}
