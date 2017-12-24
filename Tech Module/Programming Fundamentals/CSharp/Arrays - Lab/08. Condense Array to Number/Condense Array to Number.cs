namespace _08.Condense_Array_to_Number
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            if (nums.Length == 1)
            {
                Console.WriteLine("{0} is already condensed to number", nums[0]);
            }
            else
            {
                while (nums.Length > 1)
                {
                    var condensed = new int[nums.Length - 1];

                    for (int i = 0; i < nums.Length - 1; i++)
                    {
                        condensed[i] = nums[i] + nums[i + 1];
                    }

                    nums = condensed;
                }
                Console.WriteLine(string.Join(" ", nums));
            }
        }
    }
}
