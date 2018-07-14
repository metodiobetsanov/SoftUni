namespace WebServer.Application.Controllers
{
    using Server.HTTP.Contracts;
    using Application.Views;
    using Server.Enums;
    using Server.HTTP.Response;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }
    }
}