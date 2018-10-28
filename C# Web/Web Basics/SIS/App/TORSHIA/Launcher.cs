namespace TORSHIA
{
    using SIS.FRAMEWORK;

    public class Launcher
    {
        public static void Main()
        {
            //var context = new TorshiaContext();

            //for (int i = 0; i < 7; i++)
            //{
            //    var report = new Report() {
            //        Status = Models.Enums.Status.Completed,
            //        TaskId = i + 1,
            //        ReporterId = 2,
            //        ReportedOn = DateTime.UtcNow
            //    };

            //    context.Reports.Add(report);
            //    context.SaveChanges();
            //}

            WebHost.Start(new StartUp());
        }
    }
}