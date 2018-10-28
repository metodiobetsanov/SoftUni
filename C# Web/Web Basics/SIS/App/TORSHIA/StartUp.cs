namespace TORSHIA
{
    using SIS.FRAMEWORK.API;
    using SIS.FRAMEWORK.Services.Contracts;
    using TORSHIA.Services;
    using TORSHIA.Services.Contracts;

    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IUsersService, UsersService>();
            dependencyContainer.RegisterDependency<ITasksService, TasksService>();
            dependencyContainer.RegisterDependency<IReportsService, ReportsService>();
        }
    }
}