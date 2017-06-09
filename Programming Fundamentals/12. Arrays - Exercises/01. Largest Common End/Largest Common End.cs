namespace _01.Largest_Common_End
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var textOne = Console.ReadLine().Split(' ').ToArray();
            var textTwo = Console.ReadLine().Split(' ').ToArray();

            var leftRight = CountLeftToRight(textOne, textTwo);
            var rightLeft = CountRightToLeft(textOne, textTwo);

            if (leftRight > rightLeft)
            {
                Console.WriteLine(leftRight);
            }
            else
            {
                Console.WriteLine(rightLeft);
            }
        }

        private static int CountLeftToRight(string[] textOne, string[] textTwo)
        {
            var result = 0;

            while (Math.Min(textOne.Length, textTwo.Length) > result)
            {
                if (textOne[result] == textTwo[result])
                {
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        private static int CountRightToLeft(string[] textOne, string[] textTwo)
        {
            var result = 0;

            while (Math.Min(textOne.Length, textTwo.Length) > result)
            {
                if (textOne[textOne.Length - result - 1] == textTwo[textTwo.Length - result - 1])
                {
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}