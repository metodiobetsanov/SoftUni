using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Linked_Stack
{
    class Program
    {
        public static void Main()
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            stack.ToArray();
        }
    }
}
