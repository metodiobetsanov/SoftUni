namespace BashSoft.Commands
{
    using Attributes;
    using Exceptions;
    using Interfaces;

    [Alias("show")]
    public class ShowCourseCommand : Command
    {
        [Inject]
        private IDatabase repository;

        public ShowCourseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            this.CommandExecution();
        }

        private void CommandExecution()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                this.repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string userName = this.Data[2];
                this.repository.GetStudentsScoresFromCourse(courseName, userName);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}