namespace BashSoft.Commands
{
    using Exceptions;
    using IO;
    using Judge;
    using Repository;
    using System;

    public abstract class Command
    {
        private string input;

        private string[] data;

        private Tester judge;

        private StudentsRepository repository;

        private IOManager inputOutputManager;

        protected Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public string Input
        {
            get => this.input;
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }

        public string[] Data
        {
            get => this.data;
            protected set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                this.data = value;
            }
        }

        protected Tester Judge => this.judge;

        protected StudentsRepository Repository => this.repository;

        protected IOManager InputOutputManager => this.inputOutputManager;

        public abstract void Execute();
    }
}