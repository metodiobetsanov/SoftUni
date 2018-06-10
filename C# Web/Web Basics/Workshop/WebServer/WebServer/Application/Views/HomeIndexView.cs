namespace WebServer.Application.Views
{
    using Server.HTTP.Contracts;

    public class HomeIndexView : IView
    {
        public string View()
        {
            return "<body>" +
                        "<h2>Welcome</h2>" +
                   "</body>";
        }
    }
}