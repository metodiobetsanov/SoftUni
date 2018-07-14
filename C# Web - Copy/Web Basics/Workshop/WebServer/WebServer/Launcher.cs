namespace WebServer
{
    using System;
    using Server.Contracts;
    using Server;
    using Server.Routing;
    using Server.Routing.Contracts;
    using Application;

    public class Launcher : IRunnable
    {
        private WebServer webServer;
        private IApplication application;

        public void Run()
        {
            Console.WriteLine("WebServer 1.0");
            Console.Write("Please enter IPAddress:");
            string ipAddress = Console.ReadLine();
            Console.Write("Please enter port:");
            int port = int.Parse(Console.ReadLine());

            application = new MainApplication();

            IAppRouteConfig appRouteConfig = new AppRouteConfig();

            application.Start(appRouteConfig);

            webServer = new WebServer(ipAddress, port, appRouteConfig);

            webServer.Run();
        }
    }
}