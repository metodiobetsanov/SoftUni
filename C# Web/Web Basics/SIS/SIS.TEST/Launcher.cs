namespace SIS.TEST
{
    using SIS.HTTP.Enums;
    using SIS.WEBSERVER;
    using SIS.WEBSERVER.Routing;

    public class Launcher
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();

            WebServer webServer = new WebServer(8000, serverRoutingTable);
            webServer.Run();
        }
    }
}