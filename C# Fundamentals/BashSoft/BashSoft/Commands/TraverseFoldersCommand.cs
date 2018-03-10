namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    public class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
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
                this.InputOutputManager.TraverseDirectory(0);
            }
            else if (this.Data.Length == 2)
            {
                int depth;
                if (int.TryParse(this.Data[1], out depth))
                {
                    this.InputOutputManager.TraverseDirectory(depth);
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