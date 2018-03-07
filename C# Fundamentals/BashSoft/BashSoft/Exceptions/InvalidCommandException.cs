// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidCommandException.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvalidCommandException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Exceptions
{
    using System;

    /// <summary>
    /// The invalid command exception.
    /// </summary>
    public class InvalidCommandException : Exception
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string InvalidCommand = "The command '{0}' is invalid";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        public InvalidCommandException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCommandException"/> class.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        public InvalidCommandException(string input)
            : base(string.Format(InvalidCommand, input))
        {
        }
    }
}
