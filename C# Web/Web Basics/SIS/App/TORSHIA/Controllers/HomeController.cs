namespace TORSHIA.Controllers
{
    using SIS.FRAMEWORK.ActionResults.Contacts;
    using System.Collections.Generic;
    using TORSHIA.Services.Contracts;
    using TORSHIA.ViewModels;

    public class HomeController : BaseController
    {
        private readonly ITasksService tasksService;

        public HomeController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        public IActionResult Index()
        {
            if (this.Identity == null)
            {
                return this.View("Index");
            }

            var tasks = this.tasksService.All();
            var taskViewModels = new List<TaskViewModel>();

            foreach (var task in tasks)
            {
                taskViewModels.Add(new TaskViewModel()
                {
                    Id = task.Id,
                    Title = task.Title,
                    Level = task.AffectedSectors.Count
                });
            }

            this.Model.Data["TaskViewModel"] = taskViewModels;

            return this.View("IndexLoggedIn");
        }
    }
}