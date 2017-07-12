using System;

namespace _05.Invalid_Number
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            if ((num >= 100 && num <= 200) || num == 0)
            {

            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
    }
}
