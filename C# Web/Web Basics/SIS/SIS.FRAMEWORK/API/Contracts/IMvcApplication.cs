namespace SIS.FRAMEWORK.API.Contracts
{
    using SIS.FRAMEWORK.Services.Contracts;

    public interface IMvcApplication
    {
        void Configure();

        void ConfigureServices(IDependencyContainer dependencyContainer);
    }
}