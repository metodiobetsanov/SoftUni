//not finished
//to do: print results
namespace _10.Student_Groups
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            Regex regex = new Regex(@"\w+\s\W+\s\d+\s\w+");
            List<Town> townList = new List<Town>();
            List<Group> groups = new List<Group>();
            var lastTown = string.Empty;

            GetRegistrations(regex, townList, lastTown);

            foreach (var town in townList)
            {
                List<Student> students = town.Students
                    .OrderBy(s => s.RegDate)
                    .ThenBy(s => s.Name)
                    .ThenBy(s => s.Email)
                    .ToList();

                while (students.Any())
                {
                    var group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.Seats).ToList();
                    students = students.Skip(group.Town.Seats).ToList();
                    groups.Add(group);

                }
            }

            Console.WriteLine($"Created {groups.Count} groups in {townList.Count} towns:");

            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Town.ToString()} =>");
            }
            
        }

        private static void GetRegistrations(Regex regex, List<Town> townList, string lastTown)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                if (regex.IsMatch(input))
                {
                    var token = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var tmp = token[1].Trim().Split(' ').ToArray();
                    Town town = new Town();
                    town.Name = token[0];
                    town.Seats = int.Parse(tmp[0]);
                    town.Students = new List<Student>();
                    townList.Add(town);
                    lastTown = token[0];
                }
                else
                {
                    var token = input.Split('|').ToArray();
                    Student student = new Student();
                    student.Name = token[0].Trim();
                    student.Email = token[1].Trim();
                    student.RegDate = DateTime.ParseExact(token[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    var existingTown = townList.First(t => t.Name == lastTown);
                    existingTown.Students.Add(student);
                }
            }
        }
    }

    class Group
    {
        public Town Town { get; set; }

        public List<Student> Students { get; set; }
    }

    class Town
    {
        public string Name { get; set; }

        public int Seats { get; set; }

        public List<Student> Students { get; set; }
    }

    class Student
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime RegDate { get; set; }
    }
}
