using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        string textPattern = @"\[[a-zA-Z]+\<(\d+)REGEH(\d+)\>[a-zA-Z]+\]";
        
        Regex textRegex = new Regex(textPattern);

        Queue<int> indexList = new Queue<int>();

        var input = Console.ReadLine();

        foreach (Match match in textRegex.Matches(input))
        {
            var groups = match.Groups;
            indexList.Enqueue(int.Parse(groups[1].ToString()));
            indexList.Enqueue(int.Parse(groups[2].ToString()));
        }

        StringBuilder result = new StringBuilder();
        int index = 0;

        while (indexList.Count != 0)
        {
            index += indexList.Dequeue();
            index = index % (input.Length - 1);

            result.Append(input[index]);
        }

        Console.WriteLine(result);
    }
}

