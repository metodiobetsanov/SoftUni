namespace _08.Mentor_Group
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Principal;

    class Program
    {
        static void Main()
        {
            List<Mentors> mentorsList = new List<Mentors>();

            AddDates(mentorsList);

            AddCommetns(mentorsList);
            

            foreach (var mentor in mentorsList.OrderBy(m => m.Name))
            {
                var name = mentor.Name;
                var comments = mentor.Comments;
                var dates = mentor.Dates;

                Console.WriteLine($"{name}");
                Console.WriteLine("Comments:");

                foreach (var comment in comments)
                {
                    Console.WriteLine($"- {comment}");
                }

                Console.WriteLine("Dates attended:");

                foreach (var date in dates.OrderBy(d => d))
                {
                    Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                }
            }
        }

        private static void AddCommetns(List<Mentors> mentorsList)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of comments")
                {
                    break;
                }

                var token = input.Split('-').ToArray();
                var name = token[0];
                var comment = token[1];
                if (mentorsList.Any(m => m.Name == name))
                {
                    Mentors existingMentor = mentorsList.First(c => c.Name == name);

                    existingMentor.Comments.Add(comment);
                }
            }
        }

        private static void AddDates(List<Mentors> mentorsList)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of dates")
                {
                    break;
                }

                var token = input.Split(' ', ',').ToArray();
                var name = token[0];
                Mentors mentor = new Mentors();
                mentor.Name = name;
                mentor.Dates = new List<DateTime>();
                mentor.Comments = new List<string>();

                if (mentorsList.Any(m => m.Name == name))
                {
                    Mentors existingMentor = mentorsList.First(c => c.Name == name);

                    if (token.Length > 1)
                    {
                        for (int i = 1; i < token.Length; i++)
                        {
                            var date = DateTime.ParseExact(token[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            existingMentor.Dates.Add(date);
                        }
                    }
                }
                else
                {
                    if (token.Length > 1)
                    {
                        for (int i = 1; i < token.Length; i++)
                        {
                            var date = DateTime.ParseExact(token[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            mentor.Dates.Add(date);
                        }
                    }

                    mentorsList.Add(mentor);
                }
            }
        }
    }

    class Mentors
    {
        public string Name { get; set; }

        public List<DateTime> Dates { get; set; }

        public List<string> Comments { get; set; }
    }
}
