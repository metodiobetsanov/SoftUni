// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentsRepository.cs" company="MetodiObetsanov@SoftUni">
//   Copyright (c) MetodiObetsanov@SoftUni. All rights reserved.
// </copyright>
// <summary>
//   Defines the StudentsRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BashSoft.IO;
    using BashSoft.Models;
    using BashSoft.Static;

    /// <summary>
    /// The students repository.
    /// </summary>
    public class StudentsRepository
    {
        /// <summary>
        /// Bool variable, used to check if data has been loaded.
        /// </summary>
        private bool isDataInitialized;

        /// <summary>
        /// The courses collection.
        /// </summary>
        private Dictionary<string, Course> courses;

        /// <summary>
        /// The students collection.
        /// </summary>
        private Dictionary<string, Student> students;

        /// <summary>
        /// Instance of the filter class.
        /// </summary>
        private RepositoryFilter filter;

        /// <summary>
        /// Instance of the sorter class.
        /// </summary>
        private RepositorySorter sorter;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentsRepository"/> class.
        /// </summary>
        /// <param name="repositoryFilter">
        /// Initializes a instance of the filter.
        /// </param>
        /// <param name="repositorySorter">
        /// Initializes a instance of the sorter.
        /// </param>
        public StudentsRepository(RepositoryFilter repositoryFilter, RepositorySorter repositorySorter)
        {
            this.filter = repositoryFilter;
            this.sorter = repositorySorter;
        }

        /// <summary>
        /// Initializes a new instances of courses and students and calls for the ReadData method
        /// </summary>
        /// <param name="fileName">
        /// Gives the path to the file to be read. 
        /// </param>
        /// <exception cref="ArgumentException">Throws and exception if the data has been read.
        /// </exception>
        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedException);
            }

            this.courses = new Dictionary<string, Course>();
            this.students = new Dictionary<string, Student>();

            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.ReadData(fileName);
        }

        /// <summary>
        /// Set the collections to null
        /// </summary>
        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataNotInitializedExceptionMessage);
                return;
            }

            this.courses = null;
            this.students = null;

            this.isDataInitialized = false;
        }


        /// <summary>
        /// Get students scores from course.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        public void GetStudentsScoresFromCourse(string courseName, string username)
        {
            if (this.IsQueryForStudentPossiblе(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
            }
        }

        /// <summary>
        /// Get all students from course.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (var studentMarkEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentsScoresFromCourse(courseName, studentMarkEntry.Key);
                }
            }
        }

        /// <summary>
        /// Filter method
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="givenFilter">
        /// The given filter.
        /// </param>
        /// <param name="studentsToTake">
        /// The students to take.
        /// </param>
        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName]
                    .StudentsByName
                    .ToDictionary(pair => pair.Key, pair => pair.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        /// <summary>
        /// Sort method.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="comparison">
        /// The comparison.
        /// </param>
        /// <param name="studentsToTake">
        /// The students to take.
        /// </param>
        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName]
                    .StudentsByName
                    .ToDictionary(pair => pair.Key, pair => pair.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        /// <summary>
        /// This method reads the data, from the file, match it to a RegEx pattern and if mathced
        /// fill the collections.
        /// </summary>
        /// <param name="fileName">
        /// Gives the path to the file to be read.
        /// </param>
        private void ReadData(string fileName)
        {
            string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
            Regex regex = new Regex(pattern);

            string currentPath = SessionData.CurrentPath + "\\" + fileName;

            if (File.Exists(currentPath))
            {
                string[] allInputLines = File.ReadAllLines(currentPath);
                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && regex.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = regex.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string userName = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();


                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(userName))
                            {
                                this.students.Add(userName, new Student(userName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[userName];

                            course.EnrollStudent(student);

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException($"{fex.Message} at line : {line}");
                        }
                    }
                }

                this.isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                this.isDataInitialized = false;
            }
        }

        /// <summary>
        /// Check if the query for course is possible.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <returns>
        /// <see cref="bool"/>
        /// </returns>
        private bool IsQueryForCoursePossible(string courseName)
        {
            if (this.isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
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

        /// <summary>
        /// Check if the query for student is possible.
        /// </summary>
        /// <param name="courseName">
        /// The course name.
        /// </param>
        /// <param name="studentUserName">
        /// The student user name.
        /// </param>
        /// <returns>
        /// Returns true/false<see cref="bool"/>.
        /// </returns>
        private bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }
    }
}

