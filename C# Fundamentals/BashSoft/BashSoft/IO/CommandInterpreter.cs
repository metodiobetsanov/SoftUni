using System;
using System.Diagnostics;
using System.IO;

public class CommandInterpreter
{
    private Tester judge;
    private StudentsRepository repository;
    private IOManager inputOutputManager;

    public CommandInterpreter(Tester judgeTester, StudentsRepository studentsRepository, IOManager iOManager)
    {
        this.judge = judgeTester;
        this.repository = studentsRepository;
        this.inputOutputManager = iOManager;
    }

    public void InterpredCommand(string input)
    {
        string[] data = input.Split(' ');
        string command = data[0];
        command = command.ToLower();

        try
        {
            this.ParseCommand(input, data, command);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            OutputWriter.DisplayException(dnfe.Message);
        }
        catch (ArgumentOutOfRangeException aoore)
        {
            OutputWriter.DisplayException(aoore.Message);
        }
        catch (ArgumentException ae)
        {
            OutputWriter.DisplayException(ae.Message);
        }
        catch(Exception e)
        {
            OutputWriter.DisplayException(e.Message);
        }

    }

    private void ParseCommand(string input, string[] data, string command)
    {
        switch (command)
        {
            case "open":
                TryOpenFile(input, data);
                break;
            case "mkdir":
                TryCreateDirectory(input, data);
                break;
            case "is":
                TryTraverseFolder(input, data);
                break;
            case "cmp":
                TryCompareFiles(input, data);
                break;
            case "cdrel":
                TryChangePathReltive(input, data);
                break;
            case "cdabs":
                TryChangePathAbsolute(input, data);
                break;
            case "readdb":
                TryReadDataBaseFromFile(input, data);
                break;
            case "dropdb":
                TryDropDb(input, data);
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
            case "downloadasync":
                TryDownloadAsync(input, data);
                break;
            case "show":
                TryShowWantedData(input, data);
                break;

            default:
                DisplayInvalidCommandMessage(input);
                break;
        }
    }

    private  void TryShowWantedData(string input, string[] data)
    {
        if (data.Length == 2)
        {
            string courseName = data[1];
            this.repository.GetAllStudentsFromCourse(courseName);
        }
        else if (data.Length == 3)
        {
            string courseName = data[1];
            string userName = data[2];
            this.repository.GetStudentsScoresFromCourse(courseName, userName);
        }
        else
        {
            this.DisplayInvalidCommandMessage(input);
        }
    }

    private  void TryDownloadAsync(string input, string[] data)
    {
        throw new NotImplementedException();
    }

    private  void TryDownload(string input, string[] data)
    {
        throw new NotImplementedException();
    }

    private  void TryOrderAndTake(string input, string[] data)
    {
        if (CheckDataLenght(input, data, 5))
        {
            string courseName = data[1];
            string comparison = data[2].ToLower();
            string takeCommand = data[3].ToLower();
            string takeQuantity = data[4].ToLower();

            this.TryParseParametersForOrderAndTake(courseName, comparison, takeCommand, takeQuantity);
        }
    }

    private  void TryParseParametersForOrderAndTake(string courseName, string comparison, string takeCommand, string takeQuantity)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                this.repository.OrderAndTake(courseName, comparison);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                if (hasParsed)
                {
                    this.repository.OrderAndTake(courseName, comparison, studentsToTake);
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

    private  void TryFilterAndTake(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 5))
        {
            string courseName = data[1];
            string filter = data[2].ToLower();
            string takeCommand = data[3].ToLower();
            string takeQuantity = data[4].ToLower();

            this.TryParseParametersForFilterAndTake(courseName, filter, takeCommand, takeQuantity);

        }
    }

    private  void TryParseParametersForFilterAndTake(string courseName, string filter, string takeCommand, string takeQuantity)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                this.repository.FilterAndTake(courseName, filter);
            }
            else
            {
                int studentsToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studentsToTake);

                if (hasParsed)
                {
                    this.repository.FilterAndTake(courseName, filter, studentsToTake);
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

    private  void TryGetHelp(string input, string[] data)
    {
        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "make directory - mkdir: path "));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "traverse directory - ls: depth "));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "comparing files - cmp: path1 path2"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDirREl:relative path"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "change directory - changeDir:absolute path"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "read students data base - readDb: path"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "filter {courseName} excelent/average/poor  take 2/5/all students - filterExcelent (the output is written on the console)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "order increasing students - order {courseName} ascending/descending take 20/10/all (the output is written on the console)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file - download: path of file (saved in current directory)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "download file asinchronously - downloadAsynch: path of file (save in the current directory)"));
        OutputWriter.WriteMessageOnNewLine(string.Format("|{0, -98}|", "get help – help"));
        OutputWriter.WriteMessageOnNewLine($"{new string('_', 100)}");
        OutputWriter.WriteEmptyLine();
    }

    private void TryDropDb(string input, string[] data)
    {
        if (data.Length != 1)
        {
            this.DisplayInvalidCommandMessage(input);
            return;
        }

        this.repository.UnloadData();
        OutputWriter.WriteMessageOnNewLine("Database dropped!");
    }

    private  void TryReadDataBaseFromFile(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 2))
        {
            string fileName = data[1];
            this.repository.LoadData(fileName);
        }
    }

    private  void TryChangePathAbsolute(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 2))
        {
            string absPath = data[1];
            this.inputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
        }
    }

    private  void TryChangePathReltive(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 2))
        {
            string relPath = data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }

    private  void TryCompareFiles(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 3))
        {
            string firstPath = data[1];
            string secondPath = data[2];

            this.judge.CompareContent(firstPath, secondPath);
        }
    }

    private  void TryTraverseFolder(string input, string[] data)
    {
        if (data.Length == 1)
        {
            this.inputOutputManager.TraverseDirectory(0);
        }
        else if (data.Length == 2)
        {
            int depth;
            if (int.TryParse(data[1], out depth))
            {
                this.inputOutputManager.TraverseDirectory(depth);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
            }
        }
        else
        {
            this.DisplayInvalidCommandMessage(input);
        }
    }

    private  void TryCreateDirectory(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 2))
        {
            string foldereName = data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(foldereName);
        }
    }

    private  void TryOpenFile(string input, string[] data)
    {
        if (this.CheckDataLenght(input, data, 2))
        {
            string fileName = data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }

    private  void DisplayInvalidCommandMessage(string input)
    {
        OutputWriter.DisplayException($"The command '{input}' is invalid");
    }

    private  bool CheckDataLenght(string input, string[] data, int lenght)
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
