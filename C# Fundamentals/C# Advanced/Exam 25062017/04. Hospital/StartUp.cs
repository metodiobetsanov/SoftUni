using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var departments = new Dictionary<string, List<string>>();
        var doctors = new Dictionary<string, List<string>>();

        string input = String.Empty;

        while ((input = Console.ReadLine()) != "Output")
        {
            var tokken = input.Split();

            var department = tokken[0];
            var doctor = tokken[1] + " " + tokken[2];
            var patient = tokken[3];

            if (!departments.ContainsKey(department))
            {
                departments.Add(department, new List<string>());
            }

            departments[department].Add(patient);

            if (!doctors.ContainsKey(doctor))
            {
                doctors.Add(doctor, new List<string>());
            }

            doctors[doctor].Add(patient);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            var tokken = input.Split();

            if (tokken.Length == 1)
            {
                foreach (var patient in departments[tokken[0]])
                {
                    Console.WriteLine(patient);
                }
            }
            else
            {
                int roomNumber = 0;
                if(int.TryParse(tokken[1], out roomNumber))
                {
                    int roomsToSkip = 3 * (roomNumber - 1);

                    foreach (var patient in departments[tokken[0]].Skip(roomsToSkip).Take(3).OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    foreach(var patient in doctors[input].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}