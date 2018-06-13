namespace Framework
{
    using System;
    using System.Reflection;
    using WebServer;

    public static class Engine
    {
        public static void Run(WebServer server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssemblyName()
        {
            Context.Get.AssemblyName =
                Assembly.GetEntryAssembly().GetName().Name;
        }

        private static void RegisterControllersData()
        {
            Context.Get.ControllersFolder = "Controllers";
            Context.Get.ControllersSuffix = "Controller";
        }

        private static void RegisterViewsData()
        {
            Context.Get.ViewsFolder = "Views";
        }

        private static void RegisterModelsData()
        {
            Context.Get.ModelsFolder = "Models";
        }
    }
}