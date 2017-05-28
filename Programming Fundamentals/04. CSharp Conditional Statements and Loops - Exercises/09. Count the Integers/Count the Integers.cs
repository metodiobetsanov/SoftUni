namespace _09.Count_the_Integers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var counter = 0;

            try
            {
                do
                {
                    var number = int.Parse(Console.ReadLine());
                    counter++;
                }
                while (counter >= 0);
            }
            catch (Exception)
            {
                Console.WriteLine(counter);
            }
        }
    }
}
