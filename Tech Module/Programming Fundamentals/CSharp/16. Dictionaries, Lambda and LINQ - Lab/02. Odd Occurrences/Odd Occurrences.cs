namespace _02.Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Program
    {
        public static void Main()
        {
            var myList = Console.ReadLine().ToLower().Split(' ').ToList();
            var result = new Dictionary<string, int>();
            var myResults = new List<string>();

            for (int i = 0; i < myList.Count; i++)
            {
                var counter = 0;

                for (int j = myList.Count - 1; j >= i; j--)
                {
                    if (myList[i] == myList[j])
                    {
                        counter++;
                    }
                }

                if (!result.ContainsKey(myList[i]))
                {
                    result.Add(myList[i], counter);
                }
            }

            foreach (var text in result.Keys)
            {
                if (result[text] % 2 != 0)
                {
                    myResults.Add(text);
                }
            }

            Console.WriteLine(string.Join(", ",  myResults));
        }
    }
}
