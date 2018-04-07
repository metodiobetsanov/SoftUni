namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Interfaces;

    [Alias("is")]
    public class TraverseFoldersCommand : Command
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public TraverseFoldersCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            this.CommandExecution();
        }

        private void CommandExecution()
        {
            if (this.Data.Length == 1)
            {
                this.inputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                if (int.TryParse(this.Data[1], out depth))
                {
                    this.inputOutputManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new UnableToParseNumberException(this.Input);
                }
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}