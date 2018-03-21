using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Recursive_Drawing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            Print(number);
        }

        private static void Print(int number)
        {
            if (number <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', number));
            Print(number - 1);
            Console.WriteLine(new string('#', number));
        }
    }
}