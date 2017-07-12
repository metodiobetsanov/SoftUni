using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            
            Console.Write(new string('*', 2 * num));
            Console.Write(new string(' ', num));
            Console.WriteLine(new string('*', 2 * num));
            
            for (int i = 0; i < num - 2; i++)
            {
                Console.Write("*");
                Console.Write(new string('/', num * 2 - 2));
                Console.Write("*");
                if (i == (num - 1) / 2 - 1)
                    Console.Write(new string('|', num));
                else
                    Console.Write(new string(' ', num));
                Console.Write("*");
                Console.Write(new string('/', num * 2 - 2));
                Console.Write("*");
                Console.WriteLine();
            }
            
            Console.Write(new string('*', 2 * num));
            Console.Write(new string(' ', num));
            Console.WriteLine(new string('*', 2 * num));
        }
    }
}
