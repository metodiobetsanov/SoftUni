namespace _04.Sieve_of_Eratosthenes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var limit = int.Parse(Console.ReadLine());
            bool[] Primes = new bool[limit+1];
            Primes[0] = false;
            Primes[1] = false;

            for (int i = 2; i < Primes.Length; i++)
            {
                Primes[i] = true;
            }

            for (int i = 2; i * i < limit; i++)
            {
                if (Primes[i])
                {
                    for (int j = i; j < Primes.Length; j += i)
                    {
                        if (j != i)
                        {
                            Primes[j] = false;
                        }
                    }
                }
            }

            for (int i = 2; i < Primes.Length; i++)
            {
                if (Primes[i] == true)
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
