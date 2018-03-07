// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidStringException.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the InvalidStringException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Exceptions
{
    using System;

    /// <summary>
    /// The invalid string exception.
    /// </summary>
    public class InvalidStringException : Exception
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStringException"/> class.
        /// </summary>
        public InvalidStringException()
            : base(NullOrEmptyValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStringException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidStringException(string message)
            : base(message)
        {
        }
    }
}
