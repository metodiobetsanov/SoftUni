namespace _08.Employee_Data
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firstName = Console.ReadLine();
            var lastName = Console.ReadLine();
            var age = Console.ReadLine();
            var gender = Console.ReadLine();
            var personalID = Console.ReadLine();
            var employeeID = Console.ReadLine();

            Console.WriteLine("First name: {0} \nLast name: {1} \nAge: {2} \nGender: {3} \nPersonal ID: {4} \nUnique Employee number: {5}",
                firstName, lastName, age, gender, personalID, employeeID);
        }
    }
}
