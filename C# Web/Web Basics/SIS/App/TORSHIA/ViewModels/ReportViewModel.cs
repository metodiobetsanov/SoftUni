namespace TORSHIA.ViewModels
{
    using TORSHIA.Models.Enums;

    public class ReportViewModel
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }

        public Status Status { get; set; }
    }
}