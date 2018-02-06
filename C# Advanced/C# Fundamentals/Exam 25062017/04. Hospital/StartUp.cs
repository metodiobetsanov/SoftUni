using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class StartUp
{
    public static void Main()
    {
        List<Department> departments = new List<Department>();
        List<Doctor> docs = new List<Doctor>();

        string command = String.Empty;

        while ((command = Console.ReadLine()) != "Output")
        {
            var tokken = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (departments.Count(x => x.Name == tokken[0]) == 0)
            {
                Department Department = new Department();
                Department.Name = tokken[0];
                departments.Add(Department);
            }

            var Dep = departments.FirstOrDefault(x => x.Name == tokken[0]);

            if (docs.Count(x => x.FirstName == tokken[1] && x.Lastname == tokken[2]) == 0)
            {
                Doctor doctor = new Doctor();
                doctor.FirstName = tokken[1];
                doctor.Lastname = tokken[2];
                docs.Add(doctor);
            }

            Doctor doc = docs.FirstOrDefault(x => x.FirstName == tokken[1] && x.Lastname == tokken[2]);

            Patient patient = new Patient();
            patient.Name = tokken[3];
            patient.Doc = doc;
            doc.Patients.Add(patient);

            int roomNumber = 1;
            if (!Dep.Rooms.ContainsKey(roomNumber))
            {
                Dep.Rooms[roomNumber] = new List<Patient>();
            }
            while (Dep.Rooms.ContainsKey(roomNumber))
            {
                if (Dep.Rooms[roomNumber].Count == 3)
                {
                    roomNumber++;
                }
                else
                {
                    break;
                }
            }

            if (Dep.Rooms[roomNumber].Count < 3 && Dep.Rooms[roomNumber].Count > 0)
            {
                Dep.Rooms[roomNumber].Add(patient);
            }
            else
            {
                Dep.Rooms[roomNumber] = new List<Patient>();
                Dep.Rooms[roomNumber].Add(patient);
            }
            
        }

        while ((command = Console.ReadLine()) != "End")
        {
            var tokken = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (tokken.Length == 1)
            {
                var dep = departments.FirstOrDefault(x => x.Name == tokken[0])?.Rooms.Values;

                foreach (var pat in dep)
                {
                    foreach (var room in pat)
                    {
                        Console.WriteLine(string.Join(" ", room.Name));
                    }
                }
            }
            else
            {
                if (departments.Select(x => x.Name).Contains(tokken[0]))
                {
                    var dep = departments
                        .FirstOrDefault(x => x.Name == tokken[0] && x.Rooms.ContainsKey(int.Parse(tokken[1])))?.Rooms
                        .Values;

                    foreach (var pat in dep)
                    {
                        foreach (var room in pat.OrderBy(x => x.Name))
                        {
                            Console.WriteLine(room.Name);
                        }
                    }
                }
                else
                {
                    var doc = docs.FirstOrDefault(x => x.FirstName == tokken[0] && x.Lastname == tokken[1])
                        .Patients
                        .ToList();

                    foreach (var pat in doc.OrderBy(x => x.Name))
                    {
                        Console.WriteLine(pat.Name);
                    }
                }
            }
        }
    }

    public class Department
    {
        public Department()
        {
            this.Rooms = new Dictionary<int, List<Patient>>();
        }

        public string Name { get; set; }
        public Dictionary<int, List<Patient>> Rooms { get; set; }

    }

    public class Patient
    {
        public string Name { get; set; }
        public Doctor Doc { get; set; }
    }

    public class Doctor
    {
        public Doctor()
        {
            this.Patients = new List<Patient>();
        }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public List<Patient> Patients { get; set; }
        
    }
}