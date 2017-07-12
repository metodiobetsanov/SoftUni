namespace _03.Water_Overflow
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberOfPipes = int.Parse(Console.ReadLine());
            var volume = 255;
            var inTank = 0;
            for (int i = 0; i < numberOfPipes; i++)
            {
                var qty = int.Parse(Console.ReadLine());
                if (volume < qty)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    inTank += qty;
                    volume -= qty;
                }
            }

            Console.WriteLine(inTank);
        }
    }
}
