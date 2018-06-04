using HTTPServer.Server;
using HTTPServer.Server.Routing;

namespace HTTPServer
{
    internal class Launcher
    {
        private static void Main(string[] args)
        {
            Run(args);
        }

        private static void Run(string[] args)
        {
            //TODO: Initialize application

            var appRouteConfig = new AppRouteConfig();
            //TODO: Configure App Route Configuration

            var server = new WebServer(5252, appRouteConfig);

            server.Run();
        }
    }
}