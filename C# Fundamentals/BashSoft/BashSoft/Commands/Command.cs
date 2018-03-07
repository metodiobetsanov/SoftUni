// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the Command type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Commands
{
    using System;
    using Exceptions;
    using IO;
    using Judge;
    using Repository;

    /// <summary>
    /// Abstract class, used fot the command pattern logic.
    /// </summary>
    public abstract class Command
    {
        /// <summary>
        /// The input.
        /// </summary>
        private string input;

        /// <summary>
        /// The data.
        /// </summary>
        private string[] data;

        /// <summary>
        /// The judge.
        /// </summary>
        private Tester judge;

        /// <summary>
        /// The repository.
        /// </summary>
        private StudentsRepository repository;

        /// <summary>
        /// The input output manager.
        /// </summary>
        private IOManager inputOutputManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="judge">
        /// The judge.
        /// </param>
        /// <param name="repository">
        /// The repository.
        /// </param>
        /// <param name="inputOutputManager">
        /// The input output manager.
        /// </param>
        protected Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        /// <exception cref="InvalidStringException">Throws an exception if value is null or empty.
        /// </exception>
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

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <exception cref="NullReferenceException">Throws an exception if value is null or empty.
        /// </exception>
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

        /// <summary>
        /// The judge.
        /// </summary>
        protected Tester Judge => this.judge;

        /// <summary>
        /// The repository.
        /// </summary>
        protected StudentsRepository Repository => this.repository;

        /// <summary>
        /// The input output manager.
        /// </summary>
        protected IOManager InputOutputManager => this.inputOutputManager;

        /// <summary>
        /// Execute method.
        /// </summary>
        public abstract void Execute();
    }
}
