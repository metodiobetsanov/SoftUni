using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Generating_01_Vectors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            int[] array = new int[number];
            var index = 0;

            Gen(array, index);
        }

        private static void Gen(int[] array, int index)
        {
            if (index > array.Length - 1)
            {
                Console.WriteLine(string.Join("", array));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                array[index] = i;
                Gen(array, index + 1);
            }
        }
    }
}