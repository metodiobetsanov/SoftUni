namespace App
{
    using WebServer;
    using Framework;
    using Framework.Routers;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var server = new WebServer(8000, new ControllerRouter());

            Engine.Run(server);
        }
    }
}