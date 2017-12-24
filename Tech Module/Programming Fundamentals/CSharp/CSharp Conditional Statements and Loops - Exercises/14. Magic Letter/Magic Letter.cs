namespace _14.Magic_Letter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var start = Convert.ToChar(Console.ReadLine());
            var end = Convert.ToChar(Console.ReadLine());
            var ban = Convert.ToChar(Console.ReadLine());

            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != ban && j != ban && k != ban)
                        {
                            Console.Write("{0}{1}{2} ", i, j, k);
                        }
                    }
                }
            }
        }
    }
}
