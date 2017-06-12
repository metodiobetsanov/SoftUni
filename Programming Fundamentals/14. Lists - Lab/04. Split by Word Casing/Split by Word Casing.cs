namespace _04.Split_by_Word_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            char[] split = { ' ', ',', ';', ':', '.', '!', '(', ')', '"','\'', '\\', '/', '[', ']' };
            var myList = Console.ReadLine().Trim().Split(split).ToList();

            var lowerCase = new List<string>();
            var mixedCase = new List<string>();
            var upperCase = new List<string>();

            for (var i = 0; i < myList.Count; i++)
            {
                var low = 0;
                var up = 0;
                var sym = 0;

                foreach (char letter in myList[i])
                {
                    if (char.IsLetter(letter))
                    {
                        if (char.IsUpper(letter))
                        {
                            up++;
                        }
                        else
                        {
                            low++;
                        }
                    }
                    else
                    {
                        sym++;
                    }
                }

                if ((low != 0 && up != 0) || sym !=0)
                {
                    mixedCase.Add(myList[i]);
                }
                else if (low == 0 && up != 0)
                {
                    upperCase.Add(myList[i]);
                }
                else if (up == 0 && low != 0)
                {
                    lowerCase.Add(myList[i]);
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));
        }
    }
}