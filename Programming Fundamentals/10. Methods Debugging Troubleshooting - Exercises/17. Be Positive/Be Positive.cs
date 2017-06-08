namespace _17.Be_Positive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var countSequences = long.Parse(Console.ReadLine());

            for (var i = 0; i < countSequences; i++)
            {
                var print = new List<int>();
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToList();

                for (int j = 0; j < input.Count; j++)
                {
                    int currentNum = input[j];

                    if (currentNum >= 0)
                    {
                        print.Add(currentNum);
                    }
                    else
                    {
                        if (j == input.Count - 1)
                        {
                            break;
                        }

                        currentNum += input[j + 1];

                        if (currentNum >= 0)
                        {
                            print.Add(currentNum);
                        }

                        j++;
                    }
                }

                if (print.Count > 0)
                {
                    Console.WriteLine(string.Join(" ", print));
                }
                else
                {
                    Console.WriteLine("(empty)");
                }
            }
        }
    }
}