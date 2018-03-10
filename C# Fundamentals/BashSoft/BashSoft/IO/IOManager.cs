namespace BashSoft.IO
{
    using Exceptions;
    using Static;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class IOManager
    {
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

        public void ChangeCurrentDirectoryAbsolute(string currentPath)
        {
            if (!Directory.Exists(currentPath))
            {
                throw new InvalidPathException();
            }

            SessionData.CurrentPath = currentPath;
        }

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