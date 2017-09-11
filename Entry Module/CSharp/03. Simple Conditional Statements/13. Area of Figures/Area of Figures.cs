using System;

namespace _13.Area_of_Figures
{
    class Program
    {
        static void Main()
        {
            string obj = Console.ReadLine();
            var result = 0.0;

            if (obj == "square")
            {
                double a = double.Parse(Console.ReadLine());
                result = a * a;
            }
            else if (obj == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = a * b;
            }
            else if (obj == "circle")
            {
                double a = double.Parse(Console.ReadLine());
                result = Math.PI * (a * a);
            }
            else if (obj == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                result = (a * b) / 2;
            }

            Console.WriteLine("{0:f3}", result);

        }
    }
}
