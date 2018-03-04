using System;
using System.Diagnostics;

public static class CommandInterpreter
{
    public static void InterpredCommand(string input)
    {
        string[] data = input.Split(' ');
        string command = data[0];

        switch (command)
        {
            case "open":
                TryOpenFile(input, data);
                break;
            case "mkdir":
                TryCreateDirectory(input, data);
                break;
            case "Is":
                TryTraverseFolder(input, data);
                break;
            case "cmp":
                TryCompareFiles(input, data);
                break;
            case "cdRel":
                TryChangePathReltive(input, data);
                break;
            case "cdAbs":
                TryChangePathAbsolute(input, data);
                break;
            case "readDb":
                TryReadDataBaseFromFile(input, data);
                break;
            case "help":
                TryGetHelp(input, data);
                break;
            case "filter":
                TryFilterAndTake(input, data);
                break;
            case "order":
                TryOrderAndTake(input, data);
                break;
            case "download":
                TryDownload(input, data);
                break;
            case "downloadAsync":
                TryDownloadAsync(input, data);
                break;
            case "show":
                TryShowWantedData(input, data);
                break;

            default: DisplayInvalidCommandMessage(input);
                break;
        }
    }

    private static void TryShowWantedData(string input, string[] data)
    {
        if (data.Length == 2)
        {
            string courseName = data[1];
            StudentsRepository.GetAllStudentsFromCourse(courseName);
        }
        else if (data.Length == 3)
        {
            string courseName = data[1];
            string userName = data[2];
            StudentsRepository.GetStudentsScoresFromCourse(courseName, userName);
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }

    private static void TryDownloadAsync(string input, string[] data)
    {
        throw new NotImplementedException();
    }

    private static void TryDownload(string input, string[] data)
    {
        throw new NotImplementedException();
    }

    private static void TryGetDecendingOrder(string input, string[] data)
    {
        throw new NotImplementedException();
    }

    private static void TryOrderAndTake(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 5))
        {
            string courseName = data[1];
            string comparison = data[2].ToLower();
            string takeCommand = data[3].ToLower();
            string takeQuantity = data[4].ToLower();

            TryParseParametersForOrderAndTake(courseName, comparison, takeCommand, takeQuantity);

        }
    }

    private static void TryParseParametersForOrderAndTake(string courseName, string comparison, string takeCommand, string takeQuantity)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                StudentsRepository.OrderAndTake(courseName, comparison);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                if (hasParsed)
                {
                    StudentsRepository.OrderAndTake(courseName, comparison, studentsToTake);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
        }
    }

    private static void TryFilterAndTake(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 5))
        {
            string courseName = data[1];
            string filter = data[2].ToLower();
            string takeCommand = data[3].ToLower();
            string takeQuantity = data[4].ToLower();

            TryParseParametersForFilterAndTake(courseName, filter, takeCommand, takeQuantity);

        }
    }

    private static void TryParseParametersForFilterAndTake(string courseName, string filter, string takeCommand, string takeQuantity)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                StudentsRepository.FilterAndTake(courseName, filter);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                if (hasParsed)
                {
                    StudentsRepository.FilterAndTake(courseName, filter, studentsToTake);
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
                }
            }
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
        }
    }

    private static void TryGetHelp(string input, string[] data)
    {
        throw new NotImplementedException();
    }

    private static void TryReadDataBaseFromFile(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 2))
        {
            string fileName = data[1];
            StudentsRepository.InitializeData(fileName);
        }
    }

    private static void TryChangePathAbsolute(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 2))
        {
            string absPath = data[1];
            IOManager.ChangeCurrentDirectoryAbsolute(absPath);
        }
    }

    private static void TryChangePathReltive(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 2))
        {
            string relPath = data[1];
            IOManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }

    private static void TryCompareFiles(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 3))
        {
            string firstPath = data[1];
            string secondPath = data[2];

            Tester.CompareContent(firstPath, secondPath);
        }
    }

    private static void TryTraverseFolder(string input, string[] data)
    {
        if (data.Length == 1)
        {
            IOManager.TraverseDirectory(0);
        }
        else if (data.Length == 2)
        {
            int depth;
            if (int.TryParse(data[1], out depth))
            {
                IOManager.TraverseDirectory(depth);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
            }
        }
        else
        {
            DisplayInvalidCommandMessage(input);
        }
    }

    private static void TryCreateDirectory(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 2))
        {
            string foldereName = data[1];
            IOManager.CreateDirectoryInCurrentFolder(foldereName);
        }
    }

    private static void TryOpenFile(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 2))
        {
            string fileName = data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }

    private static void DisplayInvalidCommandMessage(string input)
    {
        OutputWriter.DisplayException($"The command '{input}' is invalid");
    }

    private static bool CheckDataLenght(string input, string[] data, int lenght)
    {
        if (data.Length == lenght)
        {
            return true;
        }
        else
        {
            OutputWriter.DisplayException($"The command '{input}' is invalid");
        }

        return false;
    }
}
