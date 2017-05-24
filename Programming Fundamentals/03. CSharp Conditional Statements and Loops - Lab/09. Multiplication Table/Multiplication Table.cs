using System;

namespace _09.Multiplication_Table
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            for (int i = 1; i <=10; i++)
            {
                var result = number * i;
                Console.WriteLine("{0} X {1} = {2}",
                    number, i, result);
            }
        }
    }
}
