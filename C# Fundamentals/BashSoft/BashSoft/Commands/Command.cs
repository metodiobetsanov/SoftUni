using System;

public abstract class Command
{
    private string input;
    private string[] data;
    private Tester judge;
    private StudentsRepository repository;
    private IOManager inputOutputManager;

    public string Input
    {
        get { return this.input; }
        set
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
        get { return this.data; }
        set
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

    public Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
    {
        this.Input = input;
        this.Data = data;
        this.judge = judge;
        this.repository = repository;
        this.inputOutputManager = inputOutputManager;
    }

    public abstract void Execute();
}
