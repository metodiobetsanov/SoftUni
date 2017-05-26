using System;

namespace _11._5_Different_Numbers
{
    class Program
    {
        static void Main()
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            if ((Math.Max(numberOne, numberTwo) - Math.Min(numberOne,numberTwo)) < 5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int i = numberOne; i <= numberTwo; i++)
                {
                    for (int j = numberOne; j <= numberTwo; j++)
                    {
                        for (int k = numberOne; k <= numberTwo; k++)
                        {
                            for (int l = numberOne; l <= numberTwo; l++)
                            {
                                for (int m = numberOne; m <= numberTwo; m++)
                                {
                                    if (i < j && j < k && k < l && l < m)
                                    {
                                        Console.WriteLine("{0} {1} {2} {3} {4}",
                                            i,j,k,l,m);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
