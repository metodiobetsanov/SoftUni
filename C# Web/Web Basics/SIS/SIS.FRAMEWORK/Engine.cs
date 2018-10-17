

namespace SIS.FRAMEWORK
{
    using SIS.WEBSERVER;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engine
    {
        public static void Run(WebServer server)
        {
            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
