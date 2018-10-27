namespace TORSHIA.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using TORSHIA.Models;
    using TORSHIA.Services.Contracts;

    public class TasksController : BaseController
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        public IActionResult Details()
        {
            Task task = this.tasksService
                .GetTask(int.Parse(this.Request.QueryData["id"].ToString()));

            this.Model.Data["Title"] = task.Title;
            this.Model.Data["Level"] = task.AffectedSectors.Count;
            this.Model.Data["DueDate"] = task.DueDate;
            this.Model.Data["Description"] = task.Description;
            this.Model.Data["Participants"] = task.Participants;
            this.Model.Data["AffectedSectors"] = string.Join(", ", task.AffectedSectors);

            return this.View();
        }
    }
}
