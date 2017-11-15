namespace P01_HospitalDatabase.Data.Models
{
    using System;

    public class Visitation
    {
        public int VisitationId { get; set; }
        public DateTime Data { get; set; }
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
