namespace TORSHIA.Services.Contracts
{
    using System.Linq;
    using TORSHIA.Models;
    using TORSHIA.ViewModels;

    public interface ITasksService
    {
        IQueryable<Task> AllTasks();

        IQueryable<Task> All();

        Task GetTask(int id);

        Task CreateTask(CreateTaskViewModel model);

        void ReportTask(int id, string username);
    }
}