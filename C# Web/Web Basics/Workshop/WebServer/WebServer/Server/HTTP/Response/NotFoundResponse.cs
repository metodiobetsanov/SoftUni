namespace WebServer.Server.HTTP.Response
{
    using Enums;

    public class NotFoundResponse : ViewResponse

    {
        public NotFoundResponse()

            : base(HttpStatusCode.NotFound, new NotFoundView())

        {
        }
    }
}