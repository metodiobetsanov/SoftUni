//-----------------------------------------------------------------------
// <copyright file="Launcher.cs" company="MetodiObetsanov@SoftUni">
// Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace BashSoft
{
    using IO;
    using Judge;
    using Repository;

    /// <summary>
    /// StartUp class of BashSoft
    /// </summary>
    public class Launcher
    {
        /// <summary>
        /// Main method of BashSoft, initializing the structure
        /// </summary>
        public static void Main()
        {
            var tester = new Tester();
            var iOManager = new IOManager();
            var repository = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            var currentInterpreter = new CommandInterpreter(tester, repository, iOManager);
            var reader = new InputReader(currentInterpreter);

            OutputWriter.WriteMessageOnNewLine("Welcome to BashSoft [Version 0.1.0], for ? type help");
            OutputWriter.WriteMessageOnNewLine("(\u00a9) 2017 Metodi Obetsanov @SoftUni");
            OutputWriter.WriteEmptyLine();

            reader.StartReadingCommands();

            OutputWriter.WriteMessageOnNewLine("Thank you for using BashSoft!");
        }
    }
}