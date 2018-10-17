

namespace SIS.FRAMEWORK
{
    using System.Reflection;

    public class FrameworkContext
    {
        private static FrameworkContext instance;

        private static readonly object instanceLock = new object();

        private FrameworkContext()
        {
        }

        public static FrameworkContext Get
        {
            get
            {
                if (instance == null)
                {
                    lock (instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new FrameworkContext();
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
    }
}