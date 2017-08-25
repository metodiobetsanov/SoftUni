namespace _07.TakeSkip_Rope
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var numberList = new List<int>();
            var takeList = new List<int>();
            var skipList = new List<int>();
            var charList = new List<string>();
            var message = new List<string>();
            var skipTotal = 0;

            Split(input, numberList, charList);

            TakeSplit(numberList, takeList, skipList);

            for (int i = 0; i < takeList.Count; i++)
            {
                var tmp = charList.Skip(skipTotal).Take(takeList[i]);
                message.AddRange(tmp);

                skipTotal += takeList[i] + skipList[i];
            }

            Console.WriteLine(string.Join("", message));
        }

        private static void TakeSplit(List<int> numberList, List<int> takeList, List<int> skipList)
        {
            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numberList[i]);
                }
                else
                {
                    skipList.Add(numberList[i]);
                }
            }
        }

        private static void Split(string input, List<int> numberList, List<string> charList)
        {
            foreach (var letter in input)
            {
                if (char.IsDigit(letter))
                {
                    numberList.Add(int.Parse(letter.ToString()));
                }
                else
                {
                    charList.Add(letter.ToString());
                }
            }
        }
    }
}
