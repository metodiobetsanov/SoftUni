using System;

namespace _05.Foreign_Languages
{
    class Program
    {
        static void Main()
        {
            var country = Console.ReadLine().ToLower();
            if (country == "usa" || country=="england")
            {
                Console.WriteLine("English");
            }
            else if (country == "spain" || country == "argentina" || country == "mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
