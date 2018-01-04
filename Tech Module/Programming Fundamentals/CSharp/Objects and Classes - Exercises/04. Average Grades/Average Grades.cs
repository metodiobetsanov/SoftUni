namespace _04.Average_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Student[] students = Student.Read();

            var sortedStudents = students
                .Where(s => s.AverageGrade >= 5)
                .OrderBy(s => s.Name)
                .ThenByDescending(s => s.AverageGrade)
                .ToList();

            foreach (var s in sortedStudents)
            {
                var name = s.Name;
                var aGrade = s.AverageGrade;

                Console.WriteLine($"{name} -> {aGrade:f2}");
            }
        }
    }

    class Student
    {
        public Student[] Students { get; set; }

        public string Name { get; set; }

        public List<double> Grades { get; set; }

        public double AverageGrade
        {
            get
            {
                return Grades.Average();
            }
        }

        public static Student[] Read()
        {

            int n = int.Parse(Console.ReadLine());

            Student[] Students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                Students[i] = ReadStudent();
            }

            return Students;
        }

        public static Student ReadStudent()
        {
                var input = Console.ReadLine().Split(' ').ToList();

                Student s = new Student();

                s.Name = input[0];
                s.Grades = input.Skip(1).Select(double.Parse).ToList();

                return s;
        }
    }
}

