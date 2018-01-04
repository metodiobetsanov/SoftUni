namespace _04._Remove_Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> list = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                var counter = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        counter++;
                    }
                }

                if (counter % 2 == 0)
                {
                    result.Add(list[i]);
                }
            }
            
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
