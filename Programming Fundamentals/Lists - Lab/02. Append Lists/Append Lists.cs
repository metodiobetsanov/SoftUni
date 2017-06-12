using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split('|').ToArray();
            List<int> myList = new List<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                var temp = input[i].Trim().Split(' ').Select(int.Parse).ToArray();
                {
                    for (int j = 0; j < temp.Length; j++)
                    {
                        if (temp[j] != ' ')
                        {
                            myList.Add(temp[j]);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", myList));
        }
    }
}
