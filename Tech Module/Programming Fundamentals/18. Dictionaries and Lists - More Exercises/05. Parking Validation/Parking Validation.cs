namespace _05.Parking_Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Program
    {
        public static void Main()
        {
            var register = new Dictionary<string, string>();
            var lines = int.Parse(Console.ReadLine());
            string pattern = @"[A-Z][A-Z][0-9][0-9][0-9][0-9][A-Z][A-Z]";
            
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                var command = input[0];

                if (command == "register")
                {
                    var user = input[1];
                    var plate = input[2];

                    if (register.ContainsKey(user))
                    {
                        Console.WriteLine("ERROR: already registered with plate number {0}", register[user]);
                    }
                    else if (register.ContainsValue(plate))
                    {
                        Console.WriteLine("ERROR: license plate {0} is busy", plate);
                    }
                    else if (!Regex.IsMatch(plate, pattern))
                    {
                        Console.WriteLine("ERROR: invalid license plate {0}", plate);
                    }
                    else
                    {
                        register[user] = plate;
                        Console.WriteLine("{0} registered {1} successfully", user, plate);
                    }
                }

                if (command == "unregister")
                {
                    var user = input[1];

                    if (!register.ContainsKey(user))
                    {
                        Console.WriteLine("ERROR: user {0} not found", user);
                    }
                    else
                    {
                        register.Remove(user);
                        Console.WriteLine("user {0} unregistered successfully", user);
                    }
                }
            }

            foreach (var pair in register)
            {
                var user = pair.Key;
                var plate = pair.Value;

                Console.WriteLine("{0} => {1}", user, plate);
            }
        }
    }
}
