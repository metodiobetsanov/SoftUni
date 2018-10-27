namespace IRunes
{
    using IRunes.Services;
    using IRunes.Services.Contracts;
    using SIS.FRAMEWORK.API;
    using SIS.FRAMEWORK.Services;
    using SIS.FRAMEWORK.Services.Contracts;

    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUserService, UserService>();
            dependencyContainer.RegisterDependency<IUserCookieService, UserCookieService>();
        }
    }
}