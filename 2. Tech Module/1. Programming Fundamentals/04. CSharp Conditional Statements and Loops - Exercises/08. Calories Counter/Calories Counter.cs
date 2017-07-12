namespace _08.Calories_Counter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var productCount = int.Parse(Console.ReadLine());
            var counter = 1;
            var calories = 0;

            while (counter <= productCount)
            {
                counter++;
                var product = Console.ReadLine().ToLower();

                switch (product)
                {
                    case "cheese":
                        calories += 500;
                        break;
                    case "tomato sauce":
                        calories += 150;
                        break;
                    case "salami":
                        calories += 600;
                        break;
                    case "pepper":
                        calories += 50;
                        break;
                    default: break;
                }
            }

            Console.WriteLine("Total calories: {0}", calories);
        }
    }
}