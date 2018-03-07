// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidPathException.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvalidPathException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Exceptions
{
    using System;

    /// <summary>
    /// The invalid path exception.
    /// </summary>
    public class InvalidPathException : Exception
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string InvalidPath = "The source does not exist.";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPathException"/> class.
        /// </summary>
        public InvalidPathException()
            : base(InvalidPath)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPathException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidPathException(string message)
            : base(message)
        {
        }
    }
}
