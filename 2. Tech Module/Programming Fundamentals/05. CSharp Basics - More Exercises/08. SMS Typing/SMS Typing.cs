namespace _08.SMS_Typing
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var counter = 1;
            string sms = null;
            
            while (counter <= number)
            {
                counter++;
                var digit = Console.ReadLine();
                var numberOfDigits = digit.Length;
                var mainDigit = int.Parse(digit[0].ToString());
                if (mainDigit == 0)
                {
                    sms += " ";
                }
                else
                {
                    var offset = (mainDigit - 2) * 3;

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset++;
                    }

                    var letterIndex = offset + numberOfDigits - 1;
                    sms += (char)(97 + letterIndex);
                }
            }

            Console.WriteLine(sms);
        }
    }
}
