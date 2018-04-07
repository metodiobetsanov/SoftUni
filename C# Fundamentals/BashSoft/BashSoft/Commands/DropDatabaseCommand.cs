namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Interfaces;
    using IO;

    [Alias("dropdb")]
    public class DropDatabaseCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
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

            this.repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped!");
        }
    }
}