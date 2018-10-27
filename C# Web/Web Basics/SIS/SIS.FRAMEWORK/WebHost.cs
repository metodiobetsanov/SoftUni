namespace SIS.FRAMEWORK
{
    using SIS.FRAMEWORK.API.Contracts;
    using SIS.FRAMEWORK.Routers;
    using SIS.FRAMEWORK.Services;
    using SIS.FRAMEWORK.Services.Contracts;
    using SIS.WEBSERVER;
    using SIS.WEBSERVER.Api;

    public static class WebHost
    {
        private const int HostingPort = 8000;

        public static void Start(IMvcApplication application)
        {
            IDependencyContainer dependencyContainer = new DependencyContainer();
            application.ConfigureServices(dependencyContainer);

            IHandleable controlleRouter = new ControllerRouter(dependencyContainer);
            IHandleable resourseRouter = new ResourceRouter();

            application.Configure();

            WebServer server = new WebServer(HostingPort, controlleRouter, resourseRouter);
            server.Run();
        }
    }
}