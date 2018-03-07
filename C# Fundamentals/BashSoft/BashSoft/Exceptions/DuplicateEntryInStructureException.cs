// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DuplicateEntryInStructureException.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the DuplicateEntryInStructureException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Exceptions
{
    using System;

    /// <summary>
    /// The duplicate entry in structure exception.
    /// </summary>
    public class DuplicateEntryInStructureException : Exception
    {
        /// <summary>
        /// Exception message.
        /// </summary>
        private const string DuplicateEntry = "The {0} already exists in {1}.";

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntryInStructureException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public DuplicateEntryInStructureException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateEntryInStructureException"/> class.
        /// </summary>
        /// <param name="entryName">
        /// The entry name.
        /// </param>
        /// <param name="structureName">
        /// The structure name.
        /// </param>
        public DuplicateEntryInStructureException(string entryName, string structureName)
            : base(string.Format(DuplicateEntry, entryName, structureName))
        {
        }
    }
}
