namespace Framework
{
    public class Context
    {
        private static Context Instance;

        private Context()
        {
        }

        public static Context Get => Instance == null ? (Instance = new Context()) : Instance;

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}