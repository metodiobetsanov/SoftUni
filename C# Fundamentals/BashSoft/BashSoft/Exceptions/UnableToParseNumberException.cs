// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnableToParseNumberException.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the UnableToParseNumberException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Exceptions
{
    using System;

    /// <summary>
    /// The unable to parse number exception.
    /// </summary>
    public class UnableToParseNumberException : Exception
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string UnableToParseNumber = "The sequence you've written is not a valid number.";

        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToParseNumberException"/> class.
        /// </summary>
        public UnableToParseNumberException()
            : base(UnableToParseNumber)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnableToParseNumberException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public UnableToParseNumberException(string message)
            : base(message)
        {
        }
    }
}
