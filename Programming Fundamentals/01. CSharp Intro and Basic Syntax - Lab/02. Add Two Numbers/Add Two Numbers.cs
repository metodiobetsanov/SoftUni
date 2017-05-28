namespace _02.Add_Two_Numbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            
            Console.Write("{0} + {1} = {2}",
                firstNumber,
                secondNumber,
                firstNumber + secondNumber);
        }
    }
}
