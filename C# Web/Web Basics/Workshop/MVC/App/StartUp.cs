namespace App
{
    using WebServer;
    using Framework;
    using Framework.Routers;

    public class StartUp
    {
        public static void Main()
        {
            var server = new WebServer(12345, new ControllerRouter());

            Engine.Run(server);
        }
    }
}