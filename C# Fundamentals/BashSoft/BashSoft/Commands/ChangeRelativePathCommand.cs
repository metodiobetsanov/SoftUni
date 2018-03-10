namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    public class ChangeRelativePathCommand : Command
    {
        public ChangeRelativePathCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            this.CommandExecution();
        }

        private void CommandExecution()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relPath = this.Data[1];
            this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}