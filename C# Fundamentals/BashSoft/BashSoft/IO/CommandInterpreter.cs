namespace BashSoft.IO
{
    using BashSoft.Attributes;
    using Commands;
    using Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;

        private IDatabase repository;

        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer tester, IDatabase data, IDirectoryManager manager)
        {
            this.judge = tester;
            this.repository = data;
            this.inputOutputManager = manager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0].ToLower();

            try
            {
                IExecutable command = this.ParseCommand(input, data, commandName);
                command.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string[] data, string commandName)
        {
            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            Type typeOfCommand = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(type => type.GetCustomAttributes(typeof(AliasAttribute))
                    .Where(atr => atr.Equals(commandName))
                    .ToArray().Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atr = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if (atr != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter
                            .First(x => x.FieldType == fieldOfCommand.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}