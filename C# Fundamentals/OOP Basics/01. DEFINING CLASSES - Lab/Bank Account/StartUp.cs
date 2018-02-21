using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArgs = command
                .Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            switch (cmdArgs[0])
            {
                case "Create":
                    Create(cmdArgs, bankAccounts);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, bankAccounts);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, bankAccounts);
                    break;
                case "Print":
                    Print(cmdArgs, bankAccounts);
                    break;
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int accId = int.Parse(cmdArgs[1]);

        if (!bankAccounts.ContainsKey(accId))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine($"Account ID{accId}, balance {bankAccounts[accId].Balance:f2}");
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int accId = int.Parse(cmdArgs[1]);
        decimal amount = decimal.Parse(cmdArgs[2]);

        if (!bankAccounts.ContainsKey(accId))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (amount > bankAccounts[accId].Balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                bankAccounts[accId].Withdraw(amount);
            }
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int accId = int.Parse(cmdArgs[1]);
        decimal amount = decimal.Parse(cmdArgs[2]);

        if (!bankAccounts.ContainsKey(accId))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            bankAccounts[accId].Deposit(amount);
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> bankAccounts)
    {
        int accId = int.Parse(cmdArgs[1]);

        if (bankAccounts.ContainsKey(accId))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            BankAccount acc = new BankAccount();
            acc.Id = accId;
            bankAccounts.Add(accId, acc);
        }
    }
}

