using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TORSHIA.Data;
using TORSHIA.Models;
using TORSHIA.Models.Enums;
using TORSHIA.Services.Contracts;

namespace TORSHIA.Services
{
    public class ReportsService : IReportsService
    {
        private readonly TorshiaContext context;

        public ReportsService(TorshiaContext context)
        {
            this.context = context;
        }

        public IQueryable<Report> AllReports()
            => this.context.Reports.Include(i => i.Task).ThenInclude(i => i.AffectedSectors).Include(i => i.Reporter);

        public Report GetReport(int id)
            => this.AllReports().FirstOrDefault(r => r.Id == id);

        public void CreateReport(Task task, User user)
        {
            Random random = new Random();
            Status status = random.Next(0, 100) % 2 == 0 ? Status.Completed : Status.Archived;

            Report report = new Report()
            {
                ReportedOn = DateTime.Now,
                TaskId = task.Id,
                ReporterId = user.Id,
                Status = status
            };

            this.context.Reports.Add(report);
            this.context.SaveChanges();
        }
    }
}