

namespace SIS.FRAMEWORK
{
    using SIS.FRAMEWORK.Routers;
    using SIS.WEBSERVER;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Launcher
    {
        public static void Main()
        {
            var server = new WebServer(80, new ControllerRouter());

            Engine.Run(server);
        }
    }
}
