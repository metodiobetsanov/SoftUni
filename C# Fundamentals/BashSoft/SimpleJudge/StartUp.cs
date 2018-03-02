using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleJudge
{
   public static class StartUp
    {
        public static void Main()
        {
            Tester.CompareContent(@"D:\GitHub\SoftUni\C# Fundamentals\BashSoft\Resources\test2.txt", @"D:\GitHub\SoftUni\C# Fundamentals\BashSoft\Resources\test3.txt");
        }
    }
}
