namespace TORSHIA.Services.Contracts
{
    using System.Linq;
    using TORSHIA.Models;

    public interface IReportsService
    {
        IQueryable<Report> AllReports();

        Report GetReport(int id);

        void CreateReport(Task task, User user);
    }
}