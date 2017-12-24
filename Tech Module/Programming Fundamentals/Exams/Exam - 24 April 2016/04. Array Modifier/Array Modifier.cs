using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArray = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            while (true)
            {
                var command = Console.ReadLine().Split(' ').ToArray();

                if (command[0] == "end")
                {
                    break;
                }

                switch (command[0])
                {
                    case "swap": SwapArray(myArray, command);
                        break;
                    case "multiply": MultiplyArray(myArray, command);
                        break;
                    case "decrease": Decrease͟Array(myArray);
                        break;

                    default: break;
                }
            }

            Console.WriteLine(string.Join(", ", myArray));
        }

        private static void Decrease͟Array(long[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] -= 1;
            }
        }

        private static void MultiplyArray(long[] myArray, string[] command)
        {
            var indexOne = int.Parse(command[1]);
            var indexTwo = int.Parse(command[2]);

            myArray[indexOne] *= myArray[indexTwo];
        }

        private static void SwapArray(long[] myArray, string[] command)
        {
            var indexOne = int.Parse(command[1]);
            var indexTwo = int.Parse(command[2]);

            var temp = myArray[indexOne];
            myArray[indexOne] = myArray[indexTwo];
            myArray[indexTwo] = temp;
        }
    }
}
