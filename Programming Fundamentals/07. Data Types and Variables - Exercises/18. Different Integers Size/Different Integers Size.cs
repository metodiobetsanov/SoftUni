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
                var test = sbyte.Parse(number);
                Console.WriteLine(
                    "{0} can fit in:\n* sbyte\n* byte\n* short\n* ushort\n* int\n* uint\n* long",
                    number);
            }
            catch (Exception)
            {
                try
                {
                    var test = byte.Parse(number);
                    Console.WriteLine(
                        "{0} can fit in:\n* byte\n* short\n* ushort\n* int\n* uint\n* long",
                        number);
                }
                catch (Exception)
                {
                    try
                    {
                        var test = short.Parse(number);
                        Console.WriteLine(
                            "{0} can fit in:\n* short\n* ushort\n* int\n* uint\n* long",
                            number);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            var test = ushort.Parse(number);
                            Console.WriteLine(
                                "{0} can fit in:\n* ushort\n* int\n* uint\n* long",
                                number);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                var test = int.Parse(number);
                                Console.WriteLine(
                                    "{0} can fit in:\n* int\n* uint\n* long",
                                    number);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    var test = uint.Parse(number);
                                    Console.WriteLine(
                                        "{0} can fit in:\n* uint\n* long",
                                        number);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        var test = uint.Parse(number);
                                        Console.WriteLine(
                                            "{0} can fit in:\n* long",
                                            number);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("{0} can't fit in any type", number);
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
