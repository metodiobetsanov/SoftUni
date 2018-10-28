using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TORSHIA.Data;
using TORSHIA.Models;
using TORSHIA.Models.Enums;
using TORSHIA.Services.Contracts;
using TORSHIA.ViewModels;

namespace TORSHIA.Services
{
    public class TasksService : ITasksService
    {
        private readonly TorshiaContext context;
        private readonly IReportsService reportsService;

        public TasksService(TorshiaContext context, IReportsService reportsService)
        {
            this.reportsService = reportsService;
            this.context = context;
        }

        public IQueryable<Task> AllTasks()
            => this.context.Tasks.Include(i => i.AffectedSectors);

        public IQueryable<Task> All()
            => this.AllTasks().Where(t => t.IsReported == false);

        public Task GetTask(int id)
            => this.AllTasks().FirstOrDefault(t => t.Id == id);

        public Task CreateTask(CreateTaskViewModel model)
        {
            Task task = new Task
            {
                Title = model.Title,
                DueDate = model.DueDate,
                Description = model.Description,
                Participants = model.Participants,
                AffectedSectors = new List<TaskSector>(),
                IsReported = false,
            };
            if (model.CustomersCheckbox != null) task.AffectedSectors.Add(new TaskSector() { Task = task, Sektor = Sector.Customers });
            if (model.MarketingCheckbox != null) task.AffectedSectors.Add(new TaskSector() { Task = task, Sektor = Sector.Marketing });
            if (model.FinancesCheckbox != null) task.AffectedSectors.Add(new TaskSector() { Task = task, Sektor = Sector.Finances });
            if (model.InternalCheckbox != null) task.AffectedSectors.Add(new TaskSector() { Task = task, Sektor = Sector.Internal });
            if (model.ManagementCheckbox != null) task.AffectedSectors.Add(new TaskSector() { Task = task, Sektor = Sector.Management });

            context.Tasks.Add(task);
            context.SaveChangesAsync();

            return task;
        }

        public void ReportTask(int id, string username)
        {
            Task task = this.GetTask(id);
            task.IsReported = true;
            User user = this.context.Users.FirstOrDefault(u => u.Username == username);
            context.SaveChanges();
            this.reportsService.CreateReport(task, user);
        }
    }
}