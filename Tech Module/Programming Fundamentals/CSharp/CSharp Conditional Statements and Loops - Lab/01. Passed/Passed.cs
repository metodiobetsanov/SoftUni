namespace _01.Passed
{
    using System;

    public class Passed
    {
        public static void Main()
        {
            var grade = double.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
