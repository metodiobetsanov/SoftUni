using System;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        string input;
        var draftManager = new DraftManager();

        while ((input = Console.ReadLine()) != "Shutdown")
        {
            var tokkens = input.Split();
            var command = tokkens[0];
            var arguments = tokkens.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(arguments));
                    break;
                default:
                    break;
            }
        }

        Console.WriteLine(draftManager.ShutDown());
    }
}

