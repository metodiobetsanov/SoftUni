namespace SIS.FRAMEWORK
{
    using SIS.WEBSERVER;
    using System;

    public class Engine
    {
        public void Run(WebServer server)
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