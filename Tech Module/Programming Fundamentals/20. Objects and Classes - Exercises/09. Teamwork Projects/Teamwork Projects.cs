namespace _09.Teamwork_Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<Teams> teamsList = new List<Teams>();

            TeamCreation(teamsList);

            AddMembers(teamsList);

            PrintTeams(teamsList);

        }

        private static void PrintTeams(List<Teams> teamsList)
        {
            foreach (var team in teamsList
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name))
            {
                var name = team.Name;
                var creator = team.Creator;
                var members = team.Members;

                Console.WriteLine($"{name}");
                Console.WriteLine($"- {creator}");

                foreach (var member in members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (var team in teamsList
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name))
            {
                var name = team.Name;

                Console.WriteLine($"{name}");
            }
        }

        private static void AddMembers(List<Teams> teamsList)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                var token = input.
                    Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var member = token[0];
                var team = token[1];

                if (!teamsList.Any(t => t.Name == team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                }
                else if (teamsList.Any(t => t.Members.Contains(member)) || teamsList.Any(t => t.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                }
                else
                {
                    var currentTeam = teamsList.First(t => t.Name == team);
                    currentTeam.Members.Add(member);
                }

            }
        }

        private static void TeamCreation(List<Teams> teamsList)
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var input = Console.ReadLine().Split('-').ToArray();
                var creator = input[0];
                var name = input[1];

                if (teamsList.Any(t => t.Name == name))
                {
                    Console.WriteLine($"Team {name} was already created!");
                }
                else if (teamsList.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    Teams team = new Teams();
                    team.Name = name;
                    team.Creator = creator;
                    team.Members = new List<string>();

                    Console.WriteLine($"Team {name} has been created by {creator}!");

                    teamsList.Add(team);
                }
            }
        }
    }

    class Teams
    {
        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }
}
