
namespace TORSHIA.Models
{
    using TORSHIA.Models.Enums;

    public class TaskSector
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }

        public Sector Sektor { get; set; }
    }
}