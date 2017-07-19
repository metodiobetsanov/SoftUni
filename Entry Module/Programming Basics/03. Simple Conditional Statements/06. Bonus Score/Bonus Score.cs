using System;

namespace _06.Bonus_Score
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter score: ");
            var num = int.Parse(Console.ReadLine());
            var bonus = 0.00;
            if (num >= 1000)
            {
                bonus = num * 0.10;
            }
            else if (num >= 100)
            {
                bonus = num * 0.20;
            }
            else
                bonus = 5;

            if (num % 2 == 0)
            {
                bonus += 1;
            }

            if (num % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine("Bonus score: {0}", bonus);
            Console.WriteLine("Total score: {0}", num + bonus);
        }
    }
}
