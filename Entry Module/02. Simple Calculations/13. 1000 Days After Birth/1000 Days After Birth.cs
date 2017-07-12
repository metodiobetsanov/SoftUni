using System;

namespace _13._1000_Days_After_Birth
{
    class Program
    {
        static void Main()
        {
            var bdate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

            Console.WriteLine(bdate.AddDays(999).ToString("dd-MM-yyyy"));
        }
    }
}