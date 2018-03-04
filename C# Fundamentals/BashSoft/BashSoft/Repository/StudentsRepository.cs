using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public static class StudentsRepository
{
    public static bool isDataInitialized = false;
    private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

    public static void InitializeData(string fileName)
    {
        if (!isDataInitialized)
        {
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
            ReadData(fileName);
        }
        else
        {
            OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedException);
        }
    }

    private static void ReadData(string fileName)
    {
        string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
        Regex regex = new Regex(pattern);

        string currentPath = SessionData.currentPath + "\\" + fileName;

        if (File.Exists(currentPath))
        {
            string[] allInputLines = File.ReadAllLines(currentPath);
            for (int line = 0; line < allInputLines.Length; line++)
            {
                if (!string.IsNullOrEmpty(allInputLines[line]) && regex.IsMatch(allInputLines[line]))
                {
                    Match currentMatch = regex.Match(allInputLines[line]);
                    string course = currentMatch.Groups[1].Value;
                    string student = currentMatch.Groups[2].Value;
                    int mark;

                    bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out mark);

                    if (hasParsedScore && mark >= 0 && mark <= 100)
                    {
                        if (!studentsByCourse.ContainsKey(course))
                        {
                            studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                        }

                        if (!studentsByCourse[course].ContainsKey(student))
                        {
                            studentsByCourse[course].Add(student, new List<int>());
                        }

                        studentsByCourse[course][student].Add(mark);
                    }
                }
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.invalidPath);
            isDataInitialized = false;
        }
    }

    public static void GetStudentsScoresFromCourse(string courseName, string username)
    {
        if (IsQueryForStudentPossiblе(courseName, username))
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[courseName][username]));
        }
    }

    public static void GetAllStudentsFromCourse(string courseName)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            OutputWriter.WriteMessageOnNewLine($"{courseName}");
            foreach (var studentMarkEntry in studentsByCourse[courseName])
            {
                OutputWriter.PrintStudent(studentMarkEntry);
            }
        }
    }

    private static bool IsQueryForCoursePossible(string courseName)
    {
        if (isDataInitialized)
        {
            if (studentsByCourse.ContainsKey(courseName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
        }

        return false;
    }

    private static bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
    {
        if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
        {
            return true;
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
        }

        return false;
    }

    public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            if (studentsToTake == null)
            {
                studentsToTake = studentsByCourse[courseName].Count;
            }

            RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
        }
    }

    public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
    {
        if (IsQueryForCoursePossible(courseName))
        {
            if (studentsToTake == null)
            {
                studentsToTake = studentsByCourse[courseName].Count;
            }

            RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
        }
    }
}

