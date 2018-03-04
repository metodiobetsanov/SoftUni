
namespace BashSoft
{
    using System;
    using System.Diagnostics;

    public class Launcher
    {
        public static void Main()
        {
            OutputWriter.WriteMessageOnNewLine($"Welcome to BashSoft [Version 0.1.0], for ? type help");
            OutputWriter.WriteMessageOnNewLine($"(\u00a9) 2017 Metodi Obetsanov @SoftUni");
            OutputWriter.WriteEmptyLine();

            InputReader.StartReadingCommands();

            OutputWriter.WriteMessageOnNewLine($"Thank you for using BashSoft!");
        }
    }
}
