namespace IRunes
{
    using IRunes.Services;
    using IRunes.Services.Contracts;
    using SIS.FRAMEWORK;
    using SIS.FRAMEWORK.Routers;
    using SIS.FRAMEWORK.Services;
    using SIS.FRAMEWORK.Services.Contracts;
    using SIS.WEBSERVER;
    using System;
    using System.Collections.Generic;

    public class Launcher
    {
        public static void Main()
        {
            var dMap = new Dictionary<Type, Type>();
            var dependencyContainer = new DependencyContainer(dMap);
            dependencyContainer.RegisterDependency<IHashService, HashService>();
            dependencyContainer.RegisterDependency<IUserService, UserService>();
            dependencyContainer.RegisterDependency<IUserCookieService, UserCookieService>();

            WebServer server = new WebServer(80, new ControllerRouter(dependencyContainer), new ResourceRouter());
            Engine engine = new Engine();
            engine.Run(server);
        }
    }
}