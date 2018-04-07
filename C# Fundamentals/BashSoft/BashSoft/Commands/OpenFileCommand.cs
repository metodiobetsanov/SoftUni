namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Static;
    using System.Diagnostics;

    [Alias("open")]
    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data)
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

            string fileName = this.Data[1];
            Process.Start(SessionData.CurrentPath + "\\" + fileName);
        }
    }
}