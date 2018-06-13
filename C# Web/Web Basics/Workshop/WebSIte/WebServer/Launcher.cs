using HTTPServer.Server;
using HTTPServer.Server.Routing;

namespace HTTPServer
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Run(args);
        }

        static void Run(string[] args)
        {
            //TODO: Initialize application

            var appRouteConfig = new AppRouteConfig();
            //TODO: Configure App Route Configuration

            var server = new WebServer(8000, appRouteConfig);

            server.Run();
        }
    }
}
