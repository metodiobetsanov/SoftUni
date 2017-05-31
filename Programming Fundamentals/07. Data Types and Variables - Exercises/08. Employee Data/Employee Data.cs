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

            Console.WriteLine(
                "First name: {0} \n" +
                "Last name: {1} \n" +
                "Age: {2} \n" +
                "Gender: {3} \n" +
                "Personal ID: {4} \n" +
                "Unique Employee number: {5}",
                firstName, 
                lastName, 
                age, 
                gender, 
                personalID, 
                employeeID);
        }
    }
}
