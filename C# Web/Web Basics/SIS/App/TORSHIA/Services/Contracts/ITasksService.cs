



namespace TORSHIA.Services.Contracts
{
    using System.Linq;
    using TORSHIA.Models;
    using TORSHIA.ViewModels;
    public interface ITasksService
    {
        IQueryable<Task> All();

        Task GetTask(int id);
    }
}
