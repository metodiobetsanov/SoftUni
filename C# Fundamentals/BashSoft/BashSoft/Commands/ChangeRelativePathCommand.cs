namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Interfaces;

    [Alias("cdrel")]
    public class ChangeRelativePathCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data)
            : base(input, data)
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
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}