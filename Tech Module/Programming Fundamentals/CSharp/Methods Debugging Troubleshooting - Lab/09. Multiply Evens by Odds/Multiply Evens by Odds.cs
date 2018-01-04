namespace _08.Multiply_Evens_by_Odds
{
    using System;

    public class Program
    {
        public static void MultiplyEvensByOdds(int number)
        {
            string input = Convert.ToString(Math.Abs(number));
            int evenSum = 0;
            int oddSum = 0;

            foreach (var digit in input)
            {
                int tmp = (int)Char.GetNumericValue(digit);

                if (tmp % 2 == 0)
                {
                    evenSum += tmp;
                }
                else
                {
                    oddSum += tmp;
                }
            }

            var result = evenSum * oddSum;
            Console.WriteLine("{0}", result);
        }

        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            MultiplyEvensByOdds(number);
        }
    }
}
