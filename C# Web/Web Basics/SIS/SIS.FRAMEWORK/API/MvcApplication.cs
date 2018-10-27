namespace SIS.FRAMEWORK.API
{
    using SIS.FRAMEWORK.API.Contracts;
    using SIS.FRAMEWORK.Services.Contracts;

    public class MvcApplication : IMvcApplication
    {
        public virtual void Configure()
        {
        }

        public virtual void ConfigureServices(IDependencyContainer dependencyContainer)
        {
        }
    }
}