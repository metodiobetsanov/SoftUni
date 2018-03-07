// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionData.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Get the current path.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Static
{
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <summary>
    /// Session data class, currently holds the current path
    /// </summary>
    public static class SessionData
    {
        /// <summary>
        /// The current path.
        /// </summary>
        public static string CurrentPath = Directory.GetCurrentDirectory();
    }
}
