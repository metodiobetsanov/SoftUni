// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutputWriter.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the OutputWriter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The output writer class, used to print on the console.
    /// </summary>
    public static class OutputWriter
    {
        /// <summary>
        /// Write message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Write message on new line.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Write empty line.
        /// </summary>
        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Display exception.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        /// <summary>
        /// Print student.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        public static void PrintStudent(KeyValuePair<string, double> student)
        {
            OutputWriter.WriteMessageOnNewLine(string.Format($"{student.Key} - {string.Join(", ", student.Value)}"));
        }
    }
}
