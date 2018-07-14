namespace SimpleMvc.Framework
{
    using System;
    using System.Reflection;
    using SimpleMvc.WebServer;

    public static class Engine
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