namespace _03.Big_Factorial
{
    using System;
    using System.Numerics;

    class Program
    {
        public static void Main()
        {
            var num = BigInteger.Parse(Console.ReadLine());
            var fakt = num;
            for (BigInteger i = 1; i < num; i++)
            {
                fakt *= i;
            }
            Console.WriteLine(fakt);
        }
    }
}
