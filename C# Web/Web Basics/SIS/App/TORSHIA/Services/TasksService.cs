using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public TasksService(TorshiaContext context)
        {
            this.context = context;
        }

        public IQueryable<Task> All()
            => this.context.Tasks.Where(t => t.IsReported == false );

        public Task GetTask(int id)
            => this.context.Tasks.First(t => t.Id == id);
    }
}
