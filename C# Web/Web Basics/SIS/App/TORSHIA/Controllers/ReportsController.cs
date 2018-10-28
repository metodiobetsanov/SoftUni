namespace TORSHIA.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Action;
    using SIS.FRAMEWORK.Attributes.Methods;
    using System.Collections.Generic;
    using System.Linq;
    using TORSHIA.Models;
    using TORSHIA.Services.Contracts;
    using TORSHIA.ViewModels;

    public class ReportsController : BaseController
    {
        private readonly IReportsService reportsService;

        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        [HttpGet]
        [Authorize("Admin")]
        public IActionResult All()
        {
            var count = 0;
            var reports = this.reportsService.AllReports();
            var reportViewModels = new List<ReportViewModel>();

            foreach (var report in reports)
            {
                reportViewModels.Add(new ReportViewModel()
                {
                    Id = report.Id,
                    Count = ++count,
                    Title = report.Task.Title,
                    Level = report.Task.AffectedSectors.Count,
                    Status = report.Status
                });
            }

            this.Model.Data["ReportViewModel"] = reportViewModels;
            return this.View();
        }

        [HttpGet]
        [Authorize("Admin")]
        public IActionResult Details()
        {
            int id = int.Parse(this.Request.QueryData["id"].ToString());

            Report report = this.reportsService.GetReport(id);

            this.Model.Data["Id"] = report.Id;
            this.Model.Data["Status"] = report.Status;
            this.Model.Data["Reporter"] = report.Reporter.Username;
            this.Model.Data["ReportedOn"] = report.ReportedOn.ToString("dd/MM/yyyy");
            this.Model.Data["Title"] = report.Task.Title;
            this.Model.Data["Level"] = report.Task.AffectedSectors.Count;
            this.Model.Data["DueDate"] = report.Task.DueDate.ToString("dd/MM/yyyy");
            this.Model.Data["Description"] = report.Task.Description;
            this.Model.Data["Participants"] = report.Task.Participants;
            this.Model.Data["AffectedSectors"] = string.Join(", ", report.Task.AffectedSectors.Select(s => s.Sektor.ToString()).ToList());
            return this.View();
        }
    }
}