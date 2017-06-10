namespace _15.Balanced_Brackets
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var balanced = 0;
            bool check = false;

            for (int i = 0; i < lines; i++)
            {
                var tmp = Console.ReadLine();

                if (tmp.Length == 1)
                {
                    switch (tmp)
                    {
                        case "(":
                            balanced += 1;
                            break;
                        case ")":
                            balanced -= 1;
                            break;
                        default: break;
                    }

                    if (!(balanced == 0 ||
                          balanced == 1))
                    {
                        check = true;
                    }
                }
            }

            Console.WriteLine(!check && balanced == 0 ? "BALANCED" : "UNBALANCED");
        }
    }
}
