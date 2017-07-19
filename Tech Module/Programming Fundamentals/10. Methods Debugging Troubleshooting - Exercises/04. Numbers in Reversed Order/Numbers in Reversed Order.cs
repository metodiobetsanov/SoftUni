using System.Linq;

namespace _04.Numbers_in_Reversed_Order
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine();
            Reverse(numbers);
        }
        
        public static void Reverse(string numbers)
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
