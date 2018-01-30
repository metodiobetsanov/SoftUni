namespace P01_StudentSystem.Data.Models
{
    using System;
    
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime RegiteredOn { get; set; }
        public DateTime Birthday { get; set; }
        
    }
}
