using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Generating_Combinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var number = int.Parse(Console.ReadLine());
            var vector = new int[number];
            int index = 0;
            int border = 0;

            GenComb(array, vector, index, border);
        }

        private static void GenComb(int[] array, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < array.Length; i++)
            {
                vector[index] = array[i];
                GenComb(array, vector, index + 1, i + 1);
            }
        }
    }
}