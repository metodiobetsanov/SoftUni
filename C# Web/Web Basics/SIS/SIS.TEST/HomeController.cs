namespace SIS.TEST
{
    using SIS.HTTP.Contracts;
    using SIS.HTTP.Enums;
    using SIS.WEBSERVER.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello World!</h1>";
            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}