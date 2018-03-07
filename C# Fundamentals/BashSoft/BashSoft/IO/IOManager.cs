// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOManager.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the IOManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Exceptions;
    using Static;

    /// <summary>
    /// The Input/Output Manager class
    /// </summary>
    public class IOManager
    {
        /// <summary>
        /// Traverse directory using DFS.
        /// </summary>
        /// <param name="depth">
        /// The depth of the traverse.
        /// </param>
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIndentation = SessionData.CurrentPath.Split('\\').Length;
            Queue<string> subFolder = new Queue<string>();
            subFolder.Enqueue(SessionData.CurrentPath);

            while (subFolder.Count != 0)
            {
                var currentPath = subFolder.Dequeue();
                int indentation = currentPath.Split('\\').Length - initialIndentation;
                OutputWriter.WriteMessageOnNewLine(string.Format($"{new string('-', indentation)}{currentPath}"));

                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf('\\');
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine($"{new string('-', indexOfLastSlash)}{fileName}");
                    }

                    foreach (string directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolder.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessException);
                }

                if (depth - indentation < 0)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Change current directory relative to the current one.
        /// </summary>
        /// <param name="relativePath">
        /// The relative path.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">Throws an exception if the destination does not exists.
        /// </exception>
        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.CurrentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("IndexOfLastSlash", ExceptionMessages.InvalidDestination);
                }
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
                currentPath += $"\\{relativePath}";
                this.ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        /// <summary>
        /// Change current directory absolute.
        /// </summary>
        /// <param name="currentPath">
        /// The current path.
        /// </param>
        /// <exception cref="InvalidPathException">Throws an exception if the destination does not exists.
        /// </exception>
        public void ChangeCurrentDirectoryAbsolute(string currentPath)
        {
            if (!Directory.Exists(currentPath))
            {
                throw new InvalidPathException();
            }

            SessionData.CurrentPath = currentPath;
        }

        /// <summary>
        /// Create directory in current folder.
        /// </summary>
        /// <param name="name">
        /// The new directory name.
        /// </param>
        /// <exception cref="InvalidFileNameException">Throws an exception if the name is not valid
        /// </exception>
        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = $"{SessionData.CurrentPath}\\{name}";

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

    }
}