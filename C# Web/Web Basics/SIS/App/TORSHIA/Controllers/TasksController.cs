namespace TORSHIA.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using SIS.FRAMEWORK.Attributes.Action;
    using SIS.FRAMEWORK.Attributes.Methods;
    using System.Linq;
    using TORSHIA.Models;
    using TORSHIA.Services.Contracts;
    using TORSHIA.ViewModels;

    public class TasksController : BaseController
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [HttpGet]
        [Authorize("Admin", "User")]
        public IActionResult Details()
        {
            Task task = this.tasksService
                .GetTask(int.Parse(this.Request.QueryData["id"].ToString()));

            this.Model.Data["Title"] = task.Title;
            this.Model.Data["Level"] = task.AffectedSectors.Count;
            this.Model.Data["DueDate"] = task.DueDate.ToString("dd/MM/yyyy");
            this.Model.Data["Description"] = task.Description;
            this.Model.Data["Participants"] = task.Participants;
            this.Model.Data["AffectedSectors"] = string.Join(", ", task.AffectedSectors.Select(s => s.Sektor.ToString()).ToList());

            return this.View();
        }

        [HttpGet]
        [Authorize("Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize("Admin")]
        public IActionResult Create(CreateTaskViewModel model)
        {
            this.tasksService.CreateTask(model);

            return this.RedirectToAction("/");
        }

        [HttpGet]
        [Authorize("Admin", "User")]
        public IActionResult ReportTask()
        {
            int id = int.Parse(this.Request.QueryData["id"].ToString());

            this.tasksService.ReportTask(id, this.Identity.Username);

            return this.RedirectToAction("/");
        }
    }
}