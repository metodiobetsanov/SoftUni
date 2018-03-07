// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tester.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Tester class, used to compare two files
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BashSoft.Judge
{
    using System;
    using System.IO;
    using IO;
    using Static;

    /// <summary>
    /// Tester class, used to compare two files
    /// </summary>
    public class Tester
    {
        /// <summary>
        /// Compare two files, and prints mismatches
        /// </summary>
        /// <param name="userOutputPath">
        /// The user output path.
        /// </param>
        /// <param name="expectedOutputPath">
        /// The expected output path.
        /// </param>
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");

            try
            {
                string mismatchPath = this.GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                string[] mismatches = this.GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out bool hasMismatch);

                this.PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException ioe)
            {
                OutputWriter.DisplayException(ioe.Message);
            }
        }

        /// <summary>
        /// The get line with possible mismatches.
        /// </summary>
        /// <param name="actualOutputLines">
        /// The actual output lines.
        /// </param>
        /// <param name="expectedOutputLines">
        /// The expected output lines.
        /// </param>
        /// <param name="hasMismatch">
        /// The has mismatch.
        /// </param>
        /// <returns>
        /// Return array of possible mismatches<see>
        ///         <cref>string[]</cref>
        ///     </see>
        /// </returns>
        private string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            string[] mismatches = new string[actualOutputLines.Length];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutputLines.Length;
            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            for (int i = 0; i < minOutputLines; i++)
            {
                string actualLine = actualOutputLines[i];
                string expectedLine = expectedOutputLines[i];

                if (!actualLine.Equals(expectedLine))
                {
                    output = $"Mismatch at line {i} -- expected: \"{expectedLine}\", actual: \"{actualLine}\"";
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        /// <summary>
        /// The print output.
        /// </summary>
        /// <param name="mismatches">
        /// The mismatches.
        /// </param>
        /// <param name="hasMismatch">
        /// The has mismatch.
        /// </param>
        /// <param name="mismatchPath">
        /// The mismatch path.
        /// </param>
        /// <exception cref="DirectoryNotFoundException">Throw an exception if there is no such directory
        /// </exception>
        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                if (!Directory.Exists(mismatchPath))
                {
                    throw new DirectoryNotFoundException(ExceptionMessages.InvalidPath);
                }
            
                File.WriteAllLines(mismatchPath, mismatches);
            
                return;
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine("Files are identical.There are no mismatches.");
            }
        }

        /// <summary>
        /// The get mismatch path.
        /// </summary>
        /// <param name="expectedOutputPath">
        /// The expected output path.
        /// </param>
        /// <returns>
        /// Returns the full path of the file<see cref="string"/>.
        /// </returns>
        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = $"{directoryPath}\\Mismatches.txt";
            return finalPath;
        }
    }
}
