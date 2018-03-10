namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    public class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            CommandExecution();
        }

        private void CommandExecution()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}