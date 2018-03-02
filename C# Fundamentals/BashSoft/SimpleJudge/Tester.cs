using System;
using System.Collections.Generic;
using System.IO;

public static class Tester
{
    public static void CompareContent(string userOutputPath, string expectedOutputPath)
    {
        OutputWriter.WriteMessageOnNewLine("Reading files...");

        try
        {
            string mismatchPath = GetMismatchPath(expectedOutputPath);

            string[] actualOutputLines = File.ReadAllLines(userOutputPath);
            string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

            bool hasMismatch;

            string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

            PrintOutput(mismatches, hasMismatch, mismatchPath);
            OutputWriter.WriteMessageOnNewLine("Files read!");
        }
        catch(FileNotFoundException)
        {
            OutputWriter.WriteMessageOnNewLine(ExceptionMessages.invalidPath);
        }
    }

    private static string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
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

    private static void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
    {
        if (hasMismatch)
        {
            foreach (var line in mismatches)
            {
                OutputWriter.WriteMessageOnNewLine(line);
            }

            try
            {
                File.WriteAllLines(mismatchPath, mismatches);
            }
            catch (DirectoryNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.invalidPath);
            }
            return;
        }
        else
        {
            OutputWriter.WriteMessageOnNewLine("Files are identical.There are no mismatches.");
        }
    }

    private static string GetMismatchPath(string expectedOutputPath)
    {
        int indexOf = expectedOutputPath.LastIndexOf('\\');
        string directoryPath = expectedOutputPath.Substring(0, indexOf);
        string finalPath = $"{directoryPath}\\Mismathces.txt";
        return finalPath;
    }
}

