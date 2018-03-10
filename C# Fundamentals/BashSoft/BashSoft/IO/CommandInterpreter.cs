namespace BashSoft.IO
{
    using Commands;
    using Exceptions;
    using Judge;
    using Repository;
    using System;

    public class CommandInterpreter
    {
        private Tester judge;

        private StudentsRepository repository;

        private IOManager inputOutputManager;

        public CommandInterpreter(Tester tester, StudentsRepository data, IOManager manager)
        {
            this.judge = tester;
            this.repository = data;
            this.inputOutputManager = manager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                Command command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private Command ParseCommand(string input, string[] data, string commandName)
        {
            switch (commandName)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "is":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.inputOutputManager);
                //case "download": TO DO

                //case "downloadasync": TO DO

                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.inputOutputManager);

                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}