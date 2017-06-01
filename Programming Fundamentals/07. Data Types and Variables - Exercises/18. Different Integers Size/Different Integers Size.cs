namespace _18.Different_Integers_Size
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = Console.ReadLine();

            try
            {
                var test = long.Parse(number);
                Console.WriteLine("{0} can fit in:", test);

                if (test <= sbyte.MaxValue && test >= sbyte.MinValue)
                {
                    Console.WriteLine("* sbyte");
                }

                if (test <= byte.MaxValue && test >= byte.MinValue)
                {
                    Console.WriteLine("* byte");
                }

                if (test <= short.MaxValue && test >= short.MinValue)
                {
                    Console.WriteLine("* short");
                }

                if (test <= ushort.MaxValue && test >= ushort.MinValue)
                {
                    Console.WriteLine("* ushort");
                }

                if (test <= int.MaxValue && test >= int.MinValue)
                {
                    Console.WriteLine("* int");
                }

                if (test <= uint.MaxValue && test >= uint.MinValue)
                {
                    Console.WriteLine("* uint");
                }

                if (test <= long.MaxValue && test >= long.MinValue)
                {
                    Console.WriteLine("* long");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("{0} can't fit in any type", number);
            }
        }
    }
}
