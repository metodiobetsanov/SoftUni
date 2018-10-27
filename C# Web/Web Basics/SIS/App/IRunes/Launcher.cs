namespace IRunes
{
    using SIS.FRAMEWORK;

    public class Launcher
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}