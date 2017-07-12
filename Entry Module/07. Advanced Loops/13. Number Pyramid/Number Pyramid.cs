using System;

namespace _13.Number_Pyramid
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var ssl = 1;
            for (int col = 1; col <= number; col++)
            {
                for (int row = 1; row <= col; row++)
                {
                    Console.Write("{0} ", ssl);
                    ssl++;
                    if (ssl > number)
                    {
                        break;
                    }
                }
                if (ssl > number)
                {
                    break;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
