namespace _08.House_Builder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var priceOne = long.Parse(Console.ReadLine());
            var priceTwo = long.Parse(Console.ReadLine());

            if (priceOne <= 127 && priceTwo > 127)
            {
                Console.WriteLine("{0}", (priceOne * 4) + (priceTwo * 10));
            }
            else
            {
                Console.WriteLine("{0}", (priceOne * 10) + (priceTwo * 4));
            }
        }
    }
}
