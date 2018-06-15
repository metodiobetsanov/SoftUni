namespace Framework
{
    public class Context
    {
        private static Context instance;

        private static readonly object instanceLock = new object();

        private Context()
        {
        }

        public static Context Get {
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

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}