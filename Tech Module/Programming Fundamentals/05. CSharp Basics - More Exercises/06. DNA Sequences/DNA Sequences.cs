namespace _06.DNA_Sequences
{
    using System;

    public class Program
    {
        public static string Nucleotides(int code)
        {
            string nucleotide = null;

            switch (code)
            {
                case 1: nucleotide = "A";
                    break;
                case 2: nucleotide = "C";
                    break;
                case 3: nucleotide = "G";
                    break;
                case 4: nucleotide = "T";
                    break;
                default: break;
            }

            return nucleotide;
        }

        public static string StartEnd(int i, int j, int k, int sum)
        {
            string startEnd = null;

            if (i + j + k >= sum)
            {
                startEnd = "O";
            }
            else
            {
                startEnd = "X";
            }

            return startEnd;
        }

        public static void Main()
        {
            var sum = int.Parse(Console.ReadLine());
            var counter = 0;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        counter++;
                        
                        Console.Write(
                            "{0}{1}{2}{3}{0} ",
                            StartEnd(i, j, k, sum),
                            Nucleotides(i),
                            Nucleotides(j),
                            Nucleotides(k));

                        if (counter % 4 == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
