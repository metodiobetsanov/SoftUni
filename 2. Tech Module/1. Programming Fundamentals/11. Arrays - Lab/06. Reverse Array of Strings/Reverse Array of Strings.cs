namespace _06.Reverse_Array_of_Strings
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Trim().Split(' ').ToArray();
            
            Console.WriteLine(string.Join(" ", array.Reverse()));
        }
    }
}
