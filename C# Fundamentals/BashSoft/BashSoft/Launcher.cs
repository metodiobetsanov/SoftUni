namespace BashSoft
{
    using IO;
    using Judge;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            var tester = new Tester();
            var iOManager = new IOManager();
            var repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            var currentInterpreter = new CommandInterpreter(tester, repository, iOManager);
            var reader = new InputReader(currentInterpreter);

            OutputWriter.WriteMessageOnNewLine("Welcome to BashSoft [Version 0.1.0], for ? type help");
            OutputWriter.WriteMessageOnNewLine("(\u00a9) 2017 Metodi Obetsanov @SoftUni");
            OutputWriter.WriteEmptyLine();

            reader.StartReadingCommands();

            OutputWriter.WriteMessageOnNewLine("Thank you for using BashSoft!");
        }
    }
}