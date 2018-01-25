
namespace _01.Reverse_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> list = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < list.Count; i++)
            {
                stack.Push(list[i]);
            }

            Console.WriteLine(string.Join(" ", stack.ToArray()));
        }
    }
}
