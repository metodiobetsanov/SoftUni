namespace SimpleMvc.App
{
    using SimpleMvc.WebServer;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using System.IO;
    using System.Reflection;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var server = new WebServer(2323, new ControllerRouter(), new ResourceRouter());

            Engine.Run(server);
        }
    }
}