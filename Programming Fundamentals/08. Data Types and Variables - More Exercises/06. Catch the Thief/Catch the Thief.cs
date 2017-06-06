namespace _06.Catch_the_Thief
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numeralType = Console.ReadLine();
            var idCounts = int.Parse(Console.ReadLine());
            long maxValue = 0;
            long thiefId = long.MinValue;
            switch (numeralType)
            {
                case "sbyte":
                    maxValue = sbyte.MaxValue;
                    break;
                case "int":
                    maxValue = int.MaxValue;
                    break;
                case "long":
                    maxValue = long.MaxValue;
                    break;
            }

            for (int i = 0; i < idCounts; i++)
            {
                long tmp = long.Parse(Console.ReadLine());
                if (tmp > thiefId && tmp <= maxValue)
                {
                    thiefId = tmp;
                }
            }

            Console.WriteLine(thiefId);
        }
    }
}
