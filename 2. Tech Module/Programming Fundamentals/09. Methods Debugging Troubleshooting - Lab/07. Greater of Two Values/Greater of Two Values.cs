namespace _07.Greater_of_Two_Values
{
    using System;

    public class Program
    {
        public static void GetMax(int numberOne, int numberTwo)
        {
            Console.WriteLine("{0}", Math.Max(numberOne, numberTwo));
        }

        public static void GetMax(char charOne, char charTwo)
        {
            Console.WriteLine("{0}", (char)Math.Max((int)charOne , (int)charTwo));
        }

        public static void GetMax(string textOne, string textTwo)
        {
            if (textOne.CompareTo(textTwo) >= 0)
            {
                Console.WriteLine("{0}", textOne);
            }
            else
            {
                Console.WriteLine("{0}", textTwo);
            }
        }

        public static void Main()
        {
            var dataType = Console.ReadLine();
            var inputOne = Console.ReadLine();
            var inputTwo = Console.ReadLine();
           
            if (dataType  == "int")
            {
                int numberOne = int.Parse(inputOne);
                int numberTwo = int.Parse(inputTwo);

                GetMax(numberOne, numberTwo);
            }

            else if (dataType == "char")
            {
                char charOne = char.Parse(inputOne);
                char charTwo = char.Parse(inputTwo);

                GetMax(charOne, charTwo);
            }

            else if (dataType == "string")
            {
                GetMax(inputOne, inputTwo);
            }
        }
    }
}
