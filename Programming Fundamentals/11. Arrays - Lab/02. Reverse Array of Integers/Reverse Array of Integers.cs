namespace _02.Reverse_Array_of_Integers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var arraySize = int.Parse(Console.ReadLine());

            var array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = array.Length -1 ; i >= 0; i--)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine();
        }
    }
}
