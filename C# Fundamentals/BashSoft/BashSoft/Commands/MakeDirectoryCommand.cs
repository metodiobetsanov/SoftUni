namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Interfaces;

    [Alias("mkdir")]
    public class MakeDirectoryCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
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

            string foldereName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(foldereName);
        }
    }
}