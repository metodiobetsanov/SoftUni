
namespace BashSoft
{
    using System;
    using System.Diagnostics;

    public class Launcher
    {
        public static void Main()
        {
            Tester tester = new Tester();
            IOManager iOManager = new IOManager();
            StudentsRepository repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            CommandInterpreter currentInterpreter = new CommandInterpreter(tester, repository, iOManager);
            InputReader reader = new InputReader(currentInterpreter);


            OutputWriter.WriteMessageOnNewLine($"Welcome to BashSoft [Version 0.1.0], for ? type help");
            OutputWriter.WriteMessageOnNewLine($"(\u00a9) 2017 Metodi Obetsanov @SoftUni");
            OutputWriter.WriteEmptyLine();

            reader.StartReadingCommands();

            OutputWriter.WriteMessageOnNewLine($"Thank you for using BashSoft!");
        }
    }
}
