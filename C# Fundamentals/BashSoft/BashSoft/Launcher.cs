namespace BashSoft
{
    using Interfaces;
    using IO;
    using Judge;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager iOManager = new IOManager();
            IDatabase repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            IInterpreter currentInterpreter = new CommandInterpreter(tester, repository, iOManager);
            IReader reader = new InputReader(currentInterpreter);

            Welcome();
            reader.StartReadingCommands();
            GoodBye();
        }

        private static void Welcome()
        {
            OutputWriter.WriteMessageOnNewLine("Welcome to BashSoft [Version 0.3.0], for ? type help");
            OutputWriter.WriteMessageOnNewLine("(\u00a9) 2017 Metodi Obetsanov @SoftUni");
            OutputWriter.WriteEmptyLine();
        }

        private static void GoodBye()
        {
            OutputWriter.WriteMessageOnNewLine("Thank you for using BashSoft!");
        }
    }
}