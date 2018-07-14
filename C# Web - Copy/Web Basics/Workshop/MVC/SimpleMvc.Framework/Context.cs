using System.Reflection;

namespace SimpleMvc.Framework
{
    public class Context
    {
        private static Context instance;

        private static readonly object instanceLock = new object();

        private Context()
        {
        }

        public static Context Get
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new Context();
                        }
                    }
                }

                return instance;
            }
        }


        public string AssemblyName { get; set; } = Assembly.GetEntryAssembly().GetName().Name;

        public string ControllersFolder { get; set; } = "Controllers";

        public string ControllerSuffix { get; set; } = "Controller";

        public string ViewsFolder { get; set; } = "Views";

        public string ModelsFolder { get; set; } = "Models";

        public string ResourcesFolder { get; set; } = "Resources";
    }
}